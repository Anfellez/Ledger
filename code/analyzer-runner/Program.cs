using System;
using System.Linq;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Diagnostics;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Text.Json;

namespace AnalyzerRunner
{
 class Program
 {
 static async Task<int> Main(string[] args)
 {
 try
 {
 // Register MSBuild from the Visual Studio installation on the machine
 var instances = MSBuildLocator.QueryVisualStudioInstances().ToArray();
 if (instances.Length ==0)
 {
 Console.Error.WriteLine("未能找到已安装的 MSBuild 实例。请先安装 Visual Studio 或 Build Tools。");
 return 2;
 }

 var instance = instances.OrderByDescending(i => i.Version).First();
 MSBuildLocator.RegisterInstance(instance);
 Console.WriteLine($"Using MSBuild at: {instance.MSBuildPath}");

 using var workspace = MSBuildWorkspace.Create();

 // allow overriding solution path via first argument; default to one level up: ../ledger.sln
 var defaultSolution = Path.GetFullPath(Path.Combine("..", "ledger.sln"));
 var solutionPath = (args != null && args.Length >0 && !string.IsNullOrWhiteSpace(args[0]))
 ? Path.GetFullPath(args[0])
 : defaultSolution;

 if (!File.Exists(solutionPath))
 {
 Console.Error.WriteLine($"Solution not found: {solutionPath}");
 return 3;
 }

 Console.WriteLine($"Opening solution: {solutionPath}");
 var solution = await workspace.OpenSolutionAsync(solutionPath);

 var allDiagnostics = new List<object>();

 foreach (var project in solution.Projects)
 {
 Console.WriteLine($"\nProject: {project.Name} ({project.Language})");

 var compilation = await project.GetCompilationAsync();
 if (compilation == null)
 {
 Console.WriteLine(" 无法生成 Compilation。");
 continue;
 }

 // Run compiler diagnostics
 var diagnostics = compilation.GetDiagnostics();
 foreach (var d in diagnostics.OrderBy(d => d.Location.SourceTree?.FilePath))
 {
 var location = d.Location.IsInSource ? d.Location.GetLineSpan() : default(FileLinePositionSpan);
 var path = d.Location.IsInSource ? location.Path : "(metadata)";
 var line = d.Location.IsInSource ? location.StartLinePosition.Line +1 :0;
 Console.WriteLine($" {d.Severity} {d.Id}: {d.GetMessage()} ({path}:{line})");
 allDiagnostics.Add(new { Kind = "Compiler", Id = d.Id, d.Severity, Message = d.GetMessage(), Path = path, Line = line });
 }

 // Load analyzers from NuGet package directories in this runner's deps
 var analyzers = new List<DiagnosticAnalyzer>();
 var baseDir = AppContext.BaseDirectory;
 var candidates = Directory.GetFiles(baseDir, "*.dll", SearchOption.AllDirectories)
 .Where(f => Path.GetFileName(f).StartsWith("Microsoft.CodeAnalysis", StringComparison.OrdinalIgnoreCase)
 || Path.GetFileName(f).StartsWith("Microsoft.CodeAnalysis.NetAnalyzers", StringComparison.OrdinalIgnoreCase)
 || Path.GetFileName(f).StartsWith("Microsoft.CodeQuality.Analyzers", StringComparison.OrdinalIgnoreCase)
 || Path.GetFileName(f).StartsWith("SonarAnalyzer", StringComparison.OrdinalIgnoreCase));

 foreach (var dll in candidates.Distinct())
 {
 try
 {
 var asm = Assembly.LoadFrom(dll);
 foreach (var type in asm.GetTypes())
 {
 if (!type.IsAbstract && typeof(DiagnosticAnalyzer).IsAssignableFrom(type))
 {
 if (Activator.CreateInstance(type) is DiagnosticAnalyzer a)
 analyzers.Add(a);
 }
 }
 }
 catch { }
 }

 Console.WriteLine($"Loaded {analyzers.Count} analyzers.");
 if (analyzers.Count >0)
 {
 var withAnalyzers = compilation.WithAnalyzers(ImmutableArray.CreateRange(analyzers));
 var analyzerDiagnostics = await withAnalyzers.GetAllDiagnosticsAsync();
 foreach (var d in analyzerDiagnostics.OrderBy(d => d.Location.SourceTree?.FilePath))
 {
 var location = d.Location.IsInSource ? d.Location.GetLineSpan() : default(FileLinePositionSpan);
 var path = d.Location.IsInSource ? location.Path : "(analyzer)";
 var line = d.Location.IsInSource ? location.StartLinePosition.Line +1 :0;
 Console.WriteLine($" ANALYZER {d.Severity} {d.Id}: {d.GetMessage()} ({path}:{line})");
 allDiagnostics.Add(new { Kind = "Analyzer", Id = d.Id, d.Severity, Message = d.GetMessage(), Path = path, Line = line });
 }
 }
 }

 var outFile = Path.Combine(Directory.GetCurrentDirectory(), "diagnostics.json");
 File.WriteAllText(outFile, JsonSerializer.Serialize(allDiagnostics, new JsonSerializerOptions { WriteIndented = true }));
 Console.WriteLine($"\nWrote diagnostics to: {outFile}");
 Console.WriteLine("\n分析完成。");
 return 0;
 }
 catch (Exception ex)
 {
 Console.Error.WriteLine($"运行失败：{ex}");
 return 1;
 }
 }
 }
}

using System;
using System.Collections.Generic;
using ledger;

namespace ledger.TestsRunner
{
 class Program
 {
 static void Main(string[] args)
 {
 Console.WriteLine("Running basic checks...");
 // basic smoke tests
 var txs = new List<Transaction>
 {
 new Transaction{Date=DateTime.Today, Amount=100, Type="Income", Currency="USD"},
 new Transaction{Date=DateTime.Today, Amount=50, Type="Expense", Currency="CNY"},
 new Transaction{Date=DateTime.Today.AddDays(-10), Amount=1000, Type="Income", Currency="JPY"},
 };
 var rates = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase){ {"CNY",1m},{"USD",7m},{"JPY",0.05m} };
 var options = new FilterOptions{ DateEnabled=true, From=DateTime.Today.AddDays(-1), To=DateTime.Today, TypeIndex=0, AmountEnabled=false, BaseCurrency="CNY", ExchangeRates=rates };
 var filtered = LedgerService.FilterTransactions(txs, options);
 var summary = LedgerService.ComputeSummary(filtered, "CNY", rates);
 Console.WriteLine($"Filtered count={filtered.Count}, summary={summary.sum}");
 }
 }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ledger;

namespace ledger.Tests
{
 [TestClass]
 public class TopDownTests
 {
 private Dictionary<string, decimal> _rates = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
 {
 {"CNY",1m},{"USD",7m},{"EUR",7.5m},{"JPY",0.05m}
 };

 [TestMethod]
 [TestCategory("TopDown")]
 public void TopDown_FullWorkflow_SaveFilterLoad_Summary()
 {
 var txs = new List<Transaction>
 {
 new Transaction{Date=DateTime.Today, Amount=100, Type="Income", Currency="USD"}, //700
 new Transaction{Date=DateTime.Today, Amount=20, Type="Expense", Currency="CNY"}, //20
 new Transaction{Date=DateTime.Today.AddDays(-2), Amount=200, Type="Income", Currency="EUR"}, //1500 (outside date range)
 };

 var opt = new FilterOptions
 {
 DateEnabled = true,
 From = DateTime.Today.AddDays(-1),
 To = DateTime.Today,
 TypeIndex =0,
 AmountEnabled = true,
 MinAmount =50,
 MaxAmount =1000,
 BaseCurrency = "CNY",
 ExchangeRates = _rates
 };

 var filtered = LedgerService.FilterTransactions(txs, opt);
 // Only USD100 (700) meets MinAmount50 within date window
 Assert.AreEqual(1, filtered.Count);

 var tmp = Path.GetTempFileName();
 try
 {
 var ser = new XmlSerializer(typeof(List<Transaction>));
 using (var fs = File.Create(tmp)) ser.Serialize(fs, filtered);

 List<Transaction> loaded;
 using (var fs = File.OpenRead(tmp)) loaded = (List<Transaction>)ser.Deserialize(fs);

 Assert.IsNotNull(loaded);
 Assert.AreEqual(1, loaded.Count);

 var (count, sum) = LedgerService.ComputeSummary(loaded, opt.BaseCurrency, opt.ExchangeRates);
 Assert.AreEqual(1, count);
 Assert.AreEqual(700m, sum);
 }
 finally
 {
 try { File.Delete(tmp); } catch { }
 }
 }

 [TestMethod]
 [TestCategory("TopDown")]
 public void TopDown_Filter_With_AllOptions_Combined()
 {
 var txs = new List<Transaction>
 {
 new Transaction{Date=DateTime.Today, Amount=500, Type="Expense", Currency="EUR"}, //3750
 new Transaction{Date=DateTime.Today, Amount=100, Type="Expense", Currency="USD"}, //700
 new Transaction{Date=DateTime.Today.AddDays(-3), Amount=1000, Type="Expense", Currency="CNY"}, //1000 (outside range)
 };

 var opt = new FilterOptions
 {
 DateEnabled = true,
 From = DateTime.Today.AddDays(-1),
 To = DateTime.Today,
 TypeIndex =2, // Expense
 AmountEnabled = true,
 MinAmount =800,
 MaxAmount =4000,
 BaseCurrency = "CNY",
 ExchangeRates = _rates
 };

 var res = LedgerService.FilterTransactions(txs, opt);
 // EUR500 ->3750 matches, USD100 ->700 does not
 Assert.AreEqual(1, res.Count);
 var (c,s) = LedgerService.ComputeSummary(res, opt.BaseCurrency, opt.ExchangeRates);
 Assert.AreEqual(1, c);
 Assert.AreEqual(3750m, s);
 }
 }
}

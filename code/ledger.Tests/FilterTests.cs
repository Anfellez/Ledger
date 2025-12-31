using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ledger;

namespace ledger.Tests
{
 [TestClass]
 public class FilterTests
 {
 private List<Transaction> _transactions;
 private Dictionary<string, decimal> _rates;

 [TestInitialize]
 public void Init()
 {
 _transactions = new List<Transaction>
 {
 new Transaction{Date=DateTime.Today, Amount=100, Type="Income", Currency="USD"}, //700
 new Transaction{Date=DateTime.Today, Amount=50, Type="Expense", Currency="CNY"}, //50
 new Transaction{Date=DateTime.Today.AddDays(-10), Amount=1000, Type="Income", Currency="JPY"}, //50
 new Transaction{Date=DateTime.Today.AddDays(-2), Amount=200, Type="Expense", Currency="EUR"}, //1500
 new Transaction{Date=DateTime.Today.AddMonths(-1), Amount=0, Type="Income", Currency="CNY"}, //0
 new Transaction{Date=DateTime.Today.AddDays(-1), Amount=10, Type="Expense", Currency="USD"}, //70
 };
 _rates = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase) { {"CNY",1m},{"USD",7m},{"EUR",7.5m},{"JPY",0.05m} };
 }

 [TestMethod]
 public void Filter_ByDate()
 {
 var opt = new FilterOptions{ DateEnabled=true, From=DateTime.Today.AddDays(-1), To=DateTime.Today, TypeIndex=0, AmountEnabled=false, BaseCurrency="CNY", ExchangeRates=_rates };
 var res = LedgerService.FilterTransactions(_transactions,opt);
 Assert.AreEqual(3,res.Count); // today(2) + yesterday(1)
 }

 [TestMethod]
 public void Filter_ByDate_Boundary_NoMatch()
 {
 var opt = new FilterOptions{ DateEnabled=true, From=DateTime.Today.AddDays(-5), To=DateTime.Today.AddDays(-4), TypeIndex=0, AmountEnabled=false, BaseCurrency="CNY", ExchangeRates=_rates };
 var res = LedgerService.FilterTransactions(_transactions,opt);
 Assert.AreEqual(0,res.Count);
 }

 [TestMethod]
 public void Filter_ByType_Income()
 {
 var opt = new FilterOptions{ DateEnabled=false, TypeIndex=1, AmountEnabled=false, BaseCurrency="CNY", ExchangeRates=_rates };
 var res = LedgerService.FilterTransactions(_transactions,opt);
 Assert.AreEqual(3,res.Count);
 }

 [TestMethod]
 public void Filter_ByType_Expense()
 {
 var opt = new FilterOptions{ DateEnabled=false, TypeIndex=2, AmountEnabled=false, BaseCurrency="CNY", ExchangeRates=_rates };
 var res = LedgerService.FilterTransactions(_transactions,opt);
 Assert.AreEqual(3,res.Count);
 }

 [TestMethod]
 public void Filter_ByAmount_Min()
 {
 var opt = new FilterOptions{ DateEnabled=false, TypeIndex=0, AmountEnabled=true, MinAmount=150, MaxAmount=0, BaseCurrency="CNY", ExchangeRates=_rates };
 var res = LedgerService.FilterTransactions(_transactions,opt);
 // amounts in base:700,50,50,1500,0,70 -> should match700 and1500 ->2
 Assert.AreEqual(2,res.Count);
 }

 [TestMethod]
 public void Filter_ByAmount_Max()
 {
 var opt = new FilterOptions{ DateEnabled=false, TypeIndex=0, AmountEnabled=true, MinAmount=0, MaxAmount=100, BaseCurrency="CNY", ExchangeRates=_rates };
 var res = LedgerService.FilterTransactions(_transactions,opt);
 // base amounts <=100:50,50,0,70 ->4
 Assert.AreEqual(4,res.Count);
 }

 [TestMethod]
 public void Filter_ByAmount_MinMax_Range()
 {
 var opt = new FilterOptions{ DateEnabled=false, TypeIndex=0, AmountEnabled=true, MinAmount=60, MaxAmount=800, BaseCurrency="CNY", ExchangeRates=_rates };
 var res = LedgerService.FilterTransactions(_transactions,opt);
 // base amounts between60 and800:700 and70 ->2
 Assert.AreEqual(2,res.Count);
 }

 [TestMethod]
 public void Filter_UnknownCurrency_TreatedAsBase()
 {
 var list = new List<Transaction>(_transactions) { new Transaction{Date=DateTime.Today, Amount=5, Type="Income", Currency="ABC"} };
 var opt = new FilterOptions{ DateEnabled=false, TypeIndex=0, AmountEnabled=true, MinAmount=5, MaxAmount=0, BaseCurrency="CNY", ExchangeRates=_rates };
 var res = LedgerService.FilterTransactions(list,opt);
 // unknown currency treated as base CNY -> amount5 meets MinAmount5
 Assert.IsTrue(res.Exists(x => x.Currency=="ABC"));
 }

 [TestMethod]
 public void Filter_NoTransactions_ReturnsEmpty()
 {
 var opt = new FilterOptions{ DateEnabled=false, TypeIndex=0, AmountEnabled=false, BaseCurrency="CNY", ExchangeRates=_rates };
 var res = LedgerService.FilterTransactions(new List<Transaction>(),opt);
 Assert.AreEqual(0,res.Count);
 }

 [TestMethod]
 public void Filter_EmptyCurrency_TreatedAsBase()
 {
 var list = new List<Transaction> { new Transaction{Date=DateTime.Today, Amount=20, Type="Income", Currency=""} };
 var opt = new FilterOptions{ DateEnabled=false, TypeIndex=0, AmountEnabled=true, MinAmount=10, MaxAmount=0, BaseCurrency="CNY", ExchangeRates=_rates };
 var res = LedgerService.FilterTransactions(list,opt);
 // empty currency treated as base -> amount20 meets min10
 Assert.AreEqual(1,res.Count);
 }
 }

 [TestClass]
 public class SummaryTests
 {
 private Dictionary<string, decimal> _rates;

 [TestInitialize]
 public void Init()
 {
 _rates = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase) { {"CNY",1m},{"USD",7m},{"EUR",7.5m},{"JPY",0.05m} };
 }

 [TestMethod]
 public void ComputeSummary_AllDifferentCurrencies()
 {
 var txs = new List<Transaction>
 {
 new Transaction{Amount=100,Currency="USD"}, //700
 new Transaction{Amount=50,Currency="CNY"}, //50
 new Transaction{Amount=1000,Currency="JPY"}, //50
 };
 var (count,sum) = LedgerService.ComputeSummary(txs,"CNY",_rates);
 Assert.AreEqual(3,count);
 Assert.AreEqual(800m,sum);
 }

 [TestMethod]
 public void ComputeSummary_EmptyList()
 {
 var (count,sum) = LedgerService.ComputeSummary(new List<Transaction>(),"CNY",_rates);
 Assert.AreEqual(0,count);
 Assert.AreEqual(0m,sum);
 }

 [TestMethod]
 public void ComputeSummary_NullList()
 {
 var (count,sum) = LedgerService.ComputeSummary(null,"CNY",_rates);
 Assert.AreEqual(0,count);
 Assert.AreEqual(0m,sum);
 }

 [TestMethod]
 public void ComputeSummary_SingleTransaction()
 {
 var txs = new List<Transaction> { new Transaction{Amount=10,Currency="USD"} };
 var (count,sum) = LedgerService.ComputeSummary(txs,"CNY",_rates);
 Assert.AreEqual(1,count);
 Assert.AreEqual(70m,sum);
 }

 [TestMethod]
 public void ComputeSummary_UnknownCurrency_TreatedAsBase()
 {
 var txs = new List<Transaction> { new Transaction{Amount=5,Currency="ABC"} };
 var (count,sum) = LedgerService.ComputeSummary(txs,"CNY",_rates);
 Assert.AreEqual(1,count);
 Assert.AreEqual(5m,sum);
 }

 [TestMethod]
 public void ComputeSummary_NegativeAmounts()
 {
 var txs = new List<Transaction> { new Transaction{Amount=-10,Currency="USD"}, new Transaction{Amount=20,Currency="CNY"} };
 var (count,sum) = LedgerService.ComputeSummary(txs,"CNY",_rates);
 // -10 USD -> -70 +20 = -50
 Assert.AreEqual(2,count);
 Assert.AreEqual(-50m,sum);
 }

 [TestMethod]
 public void ComputeSummary_MixedTypesIncluded()
 {
 var txs = new List<Transaction>
 {
 new Transaction{Amount=100,Type="Income",Currency="USD"},
 new Transaction{Amount=50,Type="Expense",Currency="CNY"}
 };
 var (count,sum) = LedgerService.ComputeSummary(txs,"CNY",_rates);
 Assert.AreEqual(2,count);
 Assert.AreEqual(750m,sum);
 }

 [TestMethod]
 public void ComputeSummary_ZeroAmounts()
 {
 var txs = new List<Transaction> { new Transaction{Amount=0,Currency="CNY"}, new Transaction{Amount=0,Currency="USD"} };
 var (count,sum) = LedgerService.ComputeSummary(txs,"CNY",_rates);
 Assert.AreEqual(2,count);
 Assert.AreEqual(0m,sum);
 }

 [TestMethod]
 public void ComputeSummary_LargeNumbers()
 {
 var txs = new List<Transaction> { new Transaction{Amount=1000000,Currency="EUR"} };
 var (count,sum) = LedgerService.ComputeSummary(txs,"CNY",_rates);
 Assert.AreEqual(1,count);
 Assert.AreEqual(7500000m,sum);
 }

 [TestMethod]
 public void ComputeSummary_MultipleSmallTransactions()
 {
 var txs = new List<Transaction>();
 for (int i=0;i<20;i++) txs.Add(new Transaction{Amount=1,Currency="USD"});
 var (count,sum) = LedgerService.ComputeSummary(txs,"CNY",_rates);
 Assert.AreEqual(20,count);
 Assert.AreEqual(140m,sum);
 }
 }
}

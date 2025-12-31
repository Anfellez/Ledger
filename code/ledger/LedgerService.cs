using System;
using System.Collections.Generic;
using System.Linq;

namespace ledger
{
 public class FilterOptions
 {
 public bool DateEnabled { get; set; }
 public DateTime From { get; set; }
 public DateTime To { get; set; }
 public int TypeIndex { get; set; } //0=All,1=Income,2=Expense
 public bool AmountEnabled { get; set; }
 public decimal MinAmount { get; set; }
 public decimal MaxAmount { get; set; }
 public string BaseCurrency { get; set; } = "CNY";
 public IDictionary<string, decimal> ExchangeRates { get; set; }
 }

 public static class LedgerService
 {
 // rate means1 unit of currency = rate units of base currency
 public static decimal ConvertToBase(decimal amount, string currency, string baseCurrency, IDictionary<string, decimal> exchangeRates)
 {
 if (string.IsNullOrWhiteSpace(currency)) currency = baseCurrency;
 if (string.Equals(currency, baseCurrency, StringComparison.OrdinalIgnoreCase)) return amount;
 if (exchangeRates != null && exchangeRates.TryGetValue(currency, out var rate))
 {
 return amount * rate;
 }
 return amount; // unknown currency treated as base
 }

 public static List<Transaction> FilterTransactions(IEnumerable<Transaction> transactions, FilterOptions options)
 {
 if (transactions == null) return new List<Transaction>();
 var query = transactions.AsQueryable();

 if (options.DateEnabled)
 {
 var from = options.From.Date;
 var to = options.To.Date.AddDays(1).AddTicks(-1);
 query = query.Where(x => x.Date >= from && x.Date <= to);
 }

 if (options.TypeIndex ==1)
 {
 query = query.Where(x => string.Equals(x.Type, "Income", StringComparison.OrdinalIgnoreCase));
 }
 else if (options.TypeIndex ==2)
 {
 query = query.Where(x => string.Equals(x.Type, "Expense", StringComparison.OrdinalIgnoreCase));
 }

 if (options.AmountEnabled)
 {
 var min = options.MinAmount;
 var max = options.MaxAmount;
 if (min >0 || max >0)
 {
 if (min >0) query = query.Where(x => ConvertToBase(x.Amount, x.Currency, options.BaseCurrency, options.ExchangeRates) >= min);
 if (max >0) query = query.Where(x => ConvertToBase(x.Amount, x.Currency, options.BaseCurrency, options.ExchangeRates) <= max);
 }
 }

 return query.ToList();
 }

 public static (int count, decimal sum) ComputeSummary(IEnumerable<Transaction> transactions, string baseCurrency, IDictionary<string, decimal> exchangeRates)
 {
 var list = transactions ?? Enumerable.Empty<Transaction>();
 int count = list.Count();
 decimal sum =0m;
 foreach (var t in list)
 {
 sum += ConvertToBase(t.Amount, t.Currency, baseCurrency, exchangeRates);
 }
 return (count, sum);
 }
 }
}

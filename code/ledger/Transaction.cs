using System;

namespace ledger
{
 [Serializable]
 public class Transaction
 {
 public string Id { get; set; } = Guid.NewGuid().ToString();
 public DateTime Date { get; set; } = DateTime.Now;
 public decimal Amount { get; set; }
 public string Type { get; set; }
 public string Counterparty { get; set; }
 public string Category { get; set; }
 public string Remark { get; set; }
 public string Description { get; set; }

 // Currency code, default to CNY
 public string Currency { get; set; } = "CNY";

 public Transaction() { }
 }
}
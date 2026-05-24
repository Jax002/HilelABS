using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Transactions;

namespace BankABS.Domain
{
    [Table("ACCOUNTS", Schema = "SYSTEM")]
    public class Account
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ACCOUNTNUMBER")]
        public string AccountNumber { get; set; } = string.Empty;

        [Column("BALANCE")]
        public decimal Balance { get; set; }

        [Column("CURRENCY")]
        public string Currency { get; set; } = "UAH";

        [Column("CUSTOMERID")]
        public int CustomerId { get; set; }

        [Column("CREATEDAT")]
        public DateTime CreatedAt { get; set; }

        [Column("ISACTIVE")]
        public bool IsActive { get; set; } = true;

        [Column("ACCOUNTTYPE")]
        public string AccountType { get; set; } = "Current";

        [Column("STATUS_ID")]
        public int StatusId { get; set; } = 1;

        [Column("ACCOUNT_TYPE_ID")]
        public int AccountTypeId { get; set; } = 1;

        [Column("CURRENCY_CODE")]
        public string CurrencyCode { get; set; } = "UAH";
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();
    }
}

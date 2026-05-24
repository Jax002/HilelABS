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
        public string Currency { get; set; } = string.Empty;

        [Column("CUSTOMERID")]
        public int CustomerId { get; set; }

        [Column("CREATEDAT")]
        public DateTime CreatedAt { get; set; }

        [Column("ISACTIVE")]
        public bool IsActive { get; set; }

        [Column("ACCOUNTTYPE")]
        public string AccountType { get; set; } = string.Empty;

        [Column("STATUS_ID")]
        public int StatusId { get; set; }

        [Column("ACCOUNT_TYPE_ID")]
        public int AccountTypeId { get; set; }

        [Column("CURRENCY_CODE")]
        public string CurrencyCode { get; set; } = string.Empty;

        [Column("CurrencyId")]
        public int? CurrencyId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }
    }
}

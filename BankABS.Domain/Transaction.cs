using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankABS.Domain
{
    [Table("TRANSACTIONS")]
    public class Transaction
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("TRANSACTIONDATE")]
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("AMOUNT")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        [Column("TRANSACTIONTYPE")]
        public string TransactionType { get; set; } = string.Empty;

        [StringLength(500)]
        [Column("DESCRIPTION")]
        public string Description { get; set; } = string.Empty;

        [Column("BALANCEBEFORE")]
        public decimal BalanceBefore { get; set; }

        [Column("BALANCEAFTER")]
        public decimal BalanceAfter { get; set; }

        [Required]
        [Column("ACCOUNTID")]
        public int AccountId { get; set; }

        [Column("CUSTOMERID")]
        public int? CustomerId { get; set; }

        [Column("DEALID")]
        public int? DealId { get; set; }

        [StringLength(50)]
        [Column("REFERENCENUMBER")]
        public string ReferenceNumber { get; set; } = string.Empty;

        public virtual Account Account { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual Deal Deal { get; set; } = null!;
    }
}

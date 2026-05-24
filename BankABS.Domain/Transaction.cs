using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankABS.Domain
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string TransactionType { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public decimal BalanceBefore { get; set; }

        public decimal BalanceAfter { get; set; }

        [Required]
        public int AccountId { get; set; }

        public int? CustomerId { get; set; }

        public int? DealId { get; set; }

        [StringLength(50)]
        public string ReferenceNumber { get; set; } = string.Empty;
        public virtual Account Account { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual Deal Deal { get; set; } = null!;
    }
}

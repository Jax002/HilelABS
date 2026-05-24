using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Transactions;

namespace BankABS.Domain
{
    public class Deal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DealDate { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(100)]
        public string DealType { get; set; } = string.Empty;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal InterestRate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active";

        [Required]
        public int AccountId { get; set; }

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Transactions;

namespace BankABS.Domain
{
    [Table("DEALS", Schema = "SYSTEM")]
    public class Deal
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("DEALDATE")]
        public DateTime DealDate { get; set; }

        [Required]
        [Column("DEALTYPE")]
        public string DealType { get; set; } = null!;

        [Column("AMOUNT")]
        public decimal Amount { get; set; }

        [Column("INTERESTRATE")]
        public decimal InterestRate { get; set; }

        [Column("STARTDATE")]
        public DateTime StartDate { get; set; }

        [Column("ENDDATE")]
        public DateTime? EndDate { get; set; }

        [Column("STATUS")]
        public string Status { get; set; } = null!;

        [Required]
        [Column("ACCOUNTID")]
        public int AccountId { get; set; }

        [Column("DESCRIPTION")]
        public string? Description { get; set; }

        [Column("STATUS_ID")]
        public int StatusId { get; set; }

        [Column("DEAL_TYPE_ID")]
        public int DealTypeId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public virtual ICollection<DealPayment> Payments { get; set; } = new List<DealPayment>();
    }
}

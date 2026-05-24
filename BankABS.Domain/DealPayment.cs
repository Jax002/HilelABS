using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankABS.Domain
{
    [Table("DEAL_PAYMENTS", Schema = "SYSTEM")]
    public class DealPayment
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("DEAL_ID")]
        public int DealId { get; set; }

        [Column("PAYMENT_NUMBER")]
        public int? PaymentNumber { get; set; }

        [Column("DUE_DATE")]
        public DateTime DueDate { get; set; }

        [Column("PRINCIPAL_AMOUNT")]
        public decimal PrincipalAmount { get; set; }

        [Column("INTEREST_AMOUNT")]
        public decimal InterestAmount { get; set; }

        [Column("TOTAL_AMOUNT")]
        public decimal TotalAmount { get; set; }

        [Column("PAID_AMOUNT")]
        public decimal PaidAmount { get; set; } = 0;

        [Column("PAID_DATE")]
        public DateTime? PaidDate { get; set; }

        [Column("STATUS")]
        public string Status { get; set; } = "PENDING";

        [Column("TRANSACTION_ID")]
        public int? TransactionId { get; set; }

        // Navigation properties
        public virtual Deal Deal { get; set; } = null!;
        public virtual Transaction? Transaction { get; set; }
    }
}

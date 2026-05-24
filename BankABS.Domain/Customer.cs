using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;
using System.Transactions;

namespace BankABS.Domain
{
    [Table("CUSTOMERS", Schema = "SYSTEM")]
    public class Customer
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("FULLNAME")]
        public string FullName { get; set; } = string.Empty;

        [Column("EMAIL")]
        public string Email { get; set; } = string.Empty;

        [Column("PHONE")]
        public string Phone { get; set; } = string.Empty;

        [Column("TAXID")]
        public string TaxId { get; set; } = string.Empty;

        [Column("PASSPORT_NUMBER")]
        public string? PassportNumber { get; set; }

        [Column("DATE_OF_BIRTH")]
        public DateTime DateOfBirth { get; set; }

        [Column("ADDRESS")]
        public string? Address { get; set; }

        [Column("CREATEDAT")]
        public DateTime CreatedAt { get; set; }

        [Column("ISACTIVE")]
        public bool IsActive { get; set; } = true;
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}

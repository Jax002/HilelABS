using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankABS.Domain
{
    [Table("ACCOUNT_TYPES", Schema = "SYSTEM")]
    public class AccountType
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("CODE")]
        public string Code { get; set; } = string.Empty;

        [Column("NAME_UA")]
        public string NameUa { get; set; } = string.Empty;

        [Column("NAME_RU")]
        public string NameRu { get; set; } = string.Empty;

        [Column("DESCRIPTION")]
        public string? Description { get; set; }

        [Column("MIN_BALANCE")]
        public decimal MinBalance { get; set; }

        [Column("MAX_BALANCE")]
        public decimal? MaxBalance { get; set; }

        [Column("INTEREST_RATE")]
        public decimal InterestRate { get; set; }

        [Column("IS_ACTIVE")]
        public bool IsActive { get; set; } = true;

        [Column("SORT_ORDER")]
        public int SortOrder { get; set; }

        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}

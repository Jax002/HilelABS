using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankABS.Domain
{
    [Table("DEAL_TYPES", Schema = "SYSTEM")]
    public class DealType
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

        [Column("DEFAULT_INTEREST_RATE")]
        public decimal DefaultInterestRate { get; set; }

        [Column("DEFAULT_TERM_DAYS")]
        public int? DefaultTermDays { get; set; }

        [Column("REQUIRES_APPROVAL")]
        public bool RequiresApproval { get; set; } = false;

        [Column("MIN_AMOUNT")]
        public decimal? MinAmount { get; set; }

        [Column("MAX_AMOUNT")]
        public decimal? MaxAmount { get; set; }

        [Column("IS_ACTIVE")]
        public bool IsActive { get; set; } = true;

        [Column("SORT_ORDER")]
        public int SortOrder { get; set; }

        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();
    }
}

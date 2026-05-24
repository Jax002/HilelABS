using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankABS.Domain
{
    [Table("DEAL_STATUSES", Schema = "SYSTEM")]
    public class DealStatus
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

        [Column("COLOR_CODE")]
        public string? ColorCode { get; set; }

        [Column("SORT_ORDER")]
        public int SortOrder { get; set; }

        [Column("IS_ACTIVE")]
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();
    }
}

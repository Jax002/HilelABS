using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankABS.Domain
{
    [Table("CURRENCIES", Schema = "SYSTEM")]
    public class Currency
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

        [Column("SYMBOL")]
        public string? Symbol { get; set; }

        [Column("IS_BASE")]
        public bool IsBase { get; set; } = false;

        [Column("EXCHANGE_RATE")]
        public decimal ExchangeRate { get; set; } = 1;

        [Column("IS_ACTIVE")]
        public bool IsActive { get; set; } = true;

        [Column("SORT_ORDER")]
        public int SortOrder { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}

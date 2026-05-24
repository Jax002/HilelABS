using BankABS.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankABS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<DealPayment> DealPayments { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<DealType> DealTypes { get; set; }
        public DbSet<DealStatus> DealStatuses { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
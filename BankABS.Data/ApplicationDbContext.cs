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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("BANKABS");

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.TaxId)
                .IsUnique()
                .HasDatabaseName("IX_CUSTOMERS_TAXID");

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique()
                .HasDatabaseName("IX_CUSTOMERS_EMAIL");

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.AccountNumber)
                .IsUnique()
                .HasDatabaseName("IX_ACCOUNTS_NUMBER");

            // Настройка последовательностей для Oracle
            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Account>()
                .Property(a => a.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Deal>()
                .Property(d => d.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Id)
                .UseIdentityColumn();

            // Связи
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Deal>()
                .HasOne(d => d.Account)
                .WithMany(a => a.Deals)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
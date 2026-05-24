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
            public DbSet<Currency> Currencies { get; set; }
        }
    }
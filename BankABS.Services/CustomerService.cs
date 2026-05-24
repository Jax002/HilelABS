using BankABS.Data;
using BankABS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankABS.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers
                .Include(c => c.Accounts)
                .Include(c => c.Transactions)
                .ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers
                .Include(c => c.Accounts)
                .Include(c => c.Transactions)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            customer.CreatedAt = DateTime.UtcNow;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return false;

            customer.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Account>> GetCustomerAccountsAsync(int customerId)
        {
            return await _context.Accounts
                .Where(a => a.CustomerId == customerId && a.IsActive)
                .Include(a => a.Transactions)
                .ToListAsync();
        }

        public async Task<CustomerStatsDto> GetCustomerStatsAsync(int customerId)
        {
            var customer = await _context.Customers
                .Include(c => c.Accounts)
                .Include(c => c.Transactions)
                .FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
                return new CustomerStatsDto();

            var activeAccounts = customer.Accounts.Where(a => a.IsActive);

            return new CustomerStatsDto
            {
                TotalBalance = activeAccounts.Sum(a => a.Balance),
                ActiveAccountsCount = activeAccounts.Count(),
                ActiveDealsCount = await _context.Deals
                    .CountAsync(d => d.Account.CustomerId == customerId && d.Status == "Active"),
                TransactionsCount = customer.Transactions.Count,
                TotalOperationsAmount = customer.Transactions.Sum(t => t.Amount)
            };
        }
    }
}
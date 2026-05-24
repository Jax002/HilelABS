using BankABS.Data;
using BankABS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankABS.Services
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
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
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
            if (customer == null) return false;

            customer.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Account>> GetCustomerAccountsAsync(int customerId)
        {
            return await _context.Accounts
                .Where(a => a.CustomerId == customerId && a.IsActive)
                .ToListAsync();
        }

        public async Task<CustomerStatsDto> GetCustomerStatsAsync(int customerId)
        {
            var accounts = await _context.Accounts
                .Where(a => a.CustomerId == customerId && a.IsActive)
                .ToListAsync();

            return new CustomerStatsDto
            {
                TotalBalance = accounts.Sum(a => a.Balance),
                ActiveAccountsCount = accounts.Count,
                ActiveDealsCount = 0,
                TransactionsCount = 0,
                TotalOperationsAmount = 0
            };
        }
    }
}
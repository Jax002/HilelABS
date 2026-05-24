using BankABS.Data;
using BankABS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankABS.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts
                .Include(a => a.Customer)
                .ToListAsync();
        }

        public async Task<Account?> GetAccountByIdAsync(int id)
        {
            return await _context.Accounts
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            if (string.IsNullOrWhiteSpace(account.Currency))
            {
                throw new ArgumentException("Валюта счета обязательна для заполнения");
            }

            var currency = await _context.Currencies.FirstOrDefaultAsync(c => c.Code == account.Currency);
            if (currency == null)
            {
                throw new ArgumentException($"Валюта '{account.Currency}' не найдена в справочнике валют");
            }

            account.CreatedAt = DateTime.UtcNow;
            account.CurrencyCode = account.Currency;

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<bool> DeleteAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return false;

            account.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Account>> GetAccountsByCustomerIdAsync(int customerId)
        {
            return await _context.Accounts
                .Where(a => a.CustomerId == customerId)
                .ToListAsync();
        }
    }
}

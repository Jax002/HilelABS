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
    public class CurrencyService : ICurrencyService
    {
        private readonly ApplicationDbContext _context;

        public CurrencyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Currency>> GetAllCurrenciesAsync()
        {
            return await _context.Currencies
                .Where(c => c.IsActive)
                .OrderBy(c => c.SortOrder)
                .ToListAsync();
        }

        public async Task<Currency?> GetCurrencyByCodeAsync(string code)
        {
            return await _context.Currencies
                .FirstOrDefaultAsync(c => c.Code == code && c.IsActive);
        }
    }
}

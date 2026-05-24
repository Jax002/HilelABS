using BankABS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankABS.Services
{
    public interface ICurrencyService
    {
        Task<List<Currency>> GetAllCurrenciesAsync();
        Task<Currency?> GetCurrencyByCodeAsync(string code);
    }
}

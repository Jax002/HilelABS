using BankABS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankABS.Services
{
    public interface IAccountService
    {
        Task<List<Account>> GetAllAccountsAsync();
        Task<Account?> GetAccountByIdAsync(int id);
        Task<Account> CreateAccountAsync(Account account);
        Task<Account> UpdateAccountAsync(Account account);
        Task<bool> DeleteAccountAsync(int id);
        Task<List<Account>> GetAccountsByCustomerIdAsync(int customerId);
    }
}

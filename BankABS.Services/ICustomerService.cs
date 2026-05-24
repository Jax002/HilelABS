using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using BankABS.Domain;

namespace BankABS.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
        Task<IEnumerable<Account>> GetCustomerAccountsAsync(int customerId);
        Task<CustomerStatsDto> GetCustomerStatsAsync(int customerId);
    }
}

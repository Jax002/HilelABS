using System;
using System.Collections.Generic;
using System.Text;

namespace BankABS.Services
{
    public class CustomerStatsDto
    {
        public decimal TotalBalance { get; set; }
        public int ActiveAccountsCount { get; set; }
        public int ActiveDealsCount { get; set; }
        public int TransactionsCount { get; set; }
        public decimal TotalOperationsAmount { get; set; }
    }
}

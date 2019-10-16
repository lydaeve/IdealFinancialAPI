using IdealFinancialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Helpers
{
    public class AccountDto
    {
        public int id { get; set; }
        public double balance { get; set; }
        public double availableFunds { get; set; }
        public double creditLine { get; set; }
               
    }
    public class Utils
    {
        public static void Map(Account account , CreditLine credit, AccountDto accountDto)
        {
            try
            {
                accountDto.id = account.Id;
                accountDto.balance = account.Balance;
                accountDto.availableFunds = account.AvailableFunds;
                accountDto.creditLine = credit.Amount;
            }
            catch (Exception ex)
            {
                throw new AppExceptions(ex.Message);
            }
        }

        public static void MapTransaction(Transactions transactions, Account account)
        {
            account.Balance = transactions.Amount + account.Balance;
            account.AvailableFunds = account.AvailableFunds - transactions.Amount;
            account.CreatedAt = DateTime.Now;
        }

    }
}

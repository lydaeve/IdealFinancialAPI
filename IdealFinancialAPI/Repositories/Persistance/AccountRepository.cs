using IdealFinancialAPI.Helpers;
using IdealFinancialAPI.Models;
using IdealFinancialAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Repositories.Persistance
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {

        }

        public Account GetAccountById(int id)
        {
            Account account = Table.Include(m => m.CreditLine)
                .Where(m => m.Id == id)
                .FirstOrDefault();
         
            return account;

        }
        

    }


}



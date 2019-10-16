using IdealFinancialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Repositories.Interfaces
{
    public interface IAccountRepository :  IGenericRepository<Account>
    {
        Account GetAccountById(int id);
    }
}

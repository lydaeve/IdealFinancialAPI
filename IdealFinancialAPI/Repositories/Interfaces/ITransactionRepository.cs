using IdealFinancialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Repositories.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Transactions>
    {
        Transactions AddDrawTransaction(Transactions transactions);
        Account EditTransaction(Transactions txn, Account acc);

    }
}

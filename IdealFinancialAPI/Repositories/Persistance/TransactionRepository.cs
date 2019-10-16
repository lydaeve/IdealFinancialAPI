using IdealFinancialAPI.Helpers;
using IdealFinancialAPI.Models;
using IdealFinancialAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Repositories.Persistance
{
    public class TransactionRepository : GenericRepository<Transactions>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context)
        {
        }
        public Transactions AddDrawTransaction(Transactions transactions)
        {
            transactions.CreatedAt = DateTime.Now;

            return transactions;
        }
        public Account EditTransaction(Transactions txn, Account acc)
        {
            Utils.MapTransaction(txn, acc);

            return acc;
        }
    }
}

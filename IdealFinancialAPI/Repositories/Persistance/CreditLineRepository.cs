using IdealFinancialAPI.Models;
using IdealFinancialAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Repositories.Persistance
{
    public class CreditLineRepository : GenericRepository<CreditLine>, ICreditLineRepository
    {
        public CreditLineRepository(AppDbContext context) : base(context)
        {

        }
        public CreditLine FindByAccountId(int id)
        {
            CreditLine credit = Table
                .OrderByDescending(p => p.CreatedAt)
                .FirstOrDefault(p => p.AccountId == id);

            return credit;
        }

        public int AddCreditLine(CreditLine credit)
        {
            credit.CreatedAt = DateTime.Now;
            var id =  Add(credit);
            return id;
        }
        public double GetCreditDifference(int id)
        {
            var credit = Table
                .OrderByDescending(p => p.CreatedAt)
                .Where(p => p.AccountId == id).Take(2).ToList();

            var creditLineDifference = Math.Abs(credit[1].Amount - credit[0].Amount);

            return creditLineDifference;
        }
        public Account EditAccountFunds(double difference, Account account)
        {
            account.AvailableFunds = account.AvailableFunds + difference;
            account.CreatedAt = DateTime.Now;

            return account;
        }


    }
}






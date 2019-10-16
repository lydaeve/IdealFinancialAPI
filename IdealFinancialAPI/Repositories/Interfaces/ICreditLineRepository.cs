using IdealFinancialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Repositories.Interfaces
{
    public interface ICreditLineRepository : IGenericRepository<CreditLine>
    {
        CreditLine FindByAccountId(int id);
        int AddCreditLine(CreditLine credit);
        double GetCreditDifference(int id);
        Account EditAccountFunds(double difference, Account account);
    }
}


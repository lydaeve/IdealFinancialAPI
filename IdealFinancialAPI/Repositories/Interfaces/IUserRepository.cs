using IdealFinancialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Repositories.Interfaces
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User GetUsertById(int id);
    }
}

using IdealFinancialAPI.Models;
using IdealFinancialAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Repositories.Persistance
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
        public User GetUsertById(int id)
        {
            User user = Table.Include(m => m.Accounts)
                .Where(m=> m.Accounts.All(p => p.UserId == id))
                .Where(m => m.Id == id)
                .FirstOrDefault();

            return user;

        }
    }
}

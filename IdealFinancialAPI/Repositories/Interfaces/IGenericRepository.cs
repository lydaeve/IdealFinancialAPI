using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        int Add(T obj);
        int Save();
        int Edit(T obj);
        T FindBy(object id);
    }
}

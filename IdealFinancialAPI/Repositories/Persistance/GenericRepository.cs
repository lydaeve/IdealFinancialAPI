using IdealFinancialAPI.Models;
using IdealFinancialAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealFinancialAPI.Repositories.Persistance
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public AppDbContext Context;
        public DbSet<T> Table;

        protected GenericRepository(AppDbContext context)
        {
            Context = context;
            Table = Context.Set<T>();
        }

        public async Task<IEnumerable<T>> All()
        {
            return await Table.ToListAsync();
        }
        public T FindBy(object id)
        {
            return Table.Find(id);
        }
        public int Add(T obj)
        {
            Table.Add(obj);
            return  Save();
        }
        public int Save()
        {
            return  Context.SaveChanges();
        }
        public int Edit(T obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
            return  Save();
        }
    }
}

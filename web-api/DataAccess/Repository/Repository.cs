
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace web_api.DataAccess.Repository
{ 
    public class Repository<T> : IRepository<T>
        where T : class, new()
    {

        private readonly Microsoft.EntityFrameworkCore.DbSet<T> dbSet; 
        private readonly DatabaseContext databaseContext;

        public Repository(DatabaseContext databaseContext)  
        {
            this.dbSet = databaseContext.Set<T>();
            this.databaseContext = databaseContext;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate) 
        {
            return dbSet.Where(predicate);
        } 

        public Task<bool> Exists(Expression<Func<T, bool>> predicate)
        {
            return dbSet.AnyAsync(predicate);    
        }
    
        public IQueryable<T> Query() 
        {
            return this.dbSet;
        }

        public Task AddRange(IEnumerable<T> items)
        {
            return dbSet.AddRangeAsync(items);
        }

        public Task<int> Save() 
        {
            return this.databaseContext.SaveChangesAsync();
        }
    }
}
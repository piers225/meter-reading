
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace web_api.DataAccess.Repository
{ 
    public interface IRepository<T>
        where T : class, new()
    {
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        
        Task<bool> Exists(Expression<Func<T, bool>> predicate);

        Task AddRange(IEnumerable<T> items);

        Task<int> Save() ;
        IQueryable<T> Query();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Autoconnect.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        int Count();
        IQueryable<T> Query(Expression<Func<T, bool>> where);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> Query();
    }
}

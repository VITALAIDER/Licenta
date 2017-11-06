using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Autoconnect.Data.Infrastructure;

namespace LC_02.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private DbContext dataContext;
        private readonly IDbSet<T> dbset;

        public Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory { get; private set; }

        protected DbContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }

        public virtual int Count()
        {
            return dbset.Count();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where);
        }

        public IQueryable<T> Query()
        {
            return dbset.AsQueryable();
        }

        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

    }
}
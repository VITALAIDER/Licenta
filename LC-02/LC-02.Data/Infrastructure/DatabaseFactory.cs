using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LC_02.Data.Entities;

namespace LC_02.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DbContext dataContext;

        public DbContext Get()
        {
            if (dataContext != null) return dataContext;
            dataContext =new ProjectContext();
            dataContext.Configuration.UseDatabaseNullSemantics = true;
            return dataContext;
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}

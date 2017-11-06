using System;
using System.Data.Entity;

namespace LC_02.Data.Infrastructure
{
    public interface IDatabaseFactory: IDisposable
    {
        DbContext Get();
    }
}

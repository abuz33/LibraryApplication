using System;
using LibraryApplication.Data.Repositories;

namespace LibraryApplication.Data.UnitOfWork
{
    public  interface IUnitOfWork:IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public interface IUnitOfWork : IDisposable
    {
        EndocDataContext context { get; }

        void BeginTranaction();

        void Commit();

        void Rollback();

        void Save();

        IGenericRepository<T> GenericRepository<T>() where T : class;
    }
}

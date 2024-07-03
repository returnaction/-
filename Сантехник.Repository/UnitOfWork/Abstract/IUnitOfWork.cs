using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.CoreLayer.BaseEntities;
using Сантехник.RepositoryLayer.Repositories.Abstract;

namespace Сантехник.RepositoryLayer.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        IGenericRepositories<T> GetGenericRepository<T>() where T : class, IBaseEntity, new();
        ValueTask DisposeAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.RepositoryLayer.Context;
using Сантехник.RepositoryLayer.Repositories.Abstract;
using Сантехник.RepositoryLayer.Repositories.Concrete;
using Сантехник.RepositoryLayer.UnitOfWork.Abstract;

namespace Сантехник.RepositoryLayer.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync(); // или сделать not async
        }

        IGenericRepositories<T> IUnitOfWork.GetGeneric<T>()
        {
            return new GenericRepositories<T>(_context);
        }
    }
}

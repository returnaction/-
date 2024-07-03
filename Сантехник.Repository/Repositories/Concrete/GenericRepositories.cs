using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Сантехник.CoreLayer.BaseEntities;
using Сантехник.RepositoryLayer.Context;
using Сантехник.RepositoryLayer.Repositories.Abstract;

namespace Сантехник.RepositoryLayer.Repositories.Concrete
{
    public class GenericRepositories<T> : IGenericRepositories<T> where T: class, IBaseEntity, new()
    {
        private readonly AppDbContext _context;
        private DbSet<T> _dbSet;

        public GenericRepositories(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddEntityAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void UpdateEntity(T entity)
        {
            _dbSet.Update(entity);
        }

        public void DeleteEntity(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable GetAllList()
        {
             return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<T> GetEntityByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly AskerTrackerDbContext _context;

        protected GenericRepository(AskerTrackerDbContext context)
        {
            _context = context;
        }

        public virtual T Add(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public virtual T Update(T entity)
        {
            return _context.Update(entity).Entity;
        }

        public T Remove(T entity)
        {
            return _context.Remove(entity).Entity;
        }

        public virtual async Task<T> Get(Guid id)
        {
            return await _context.FindAsync<T>(id);
        }

        public virtual async Task<TT> Get<TT>(Expression<Func<TT, bool>> predicate,
            Expression<Func<TT, object>> include) where TT : class
        {
            return await _context.Set<TT>()
                .AsNoTracking()
                .Where(predicate)
                .Include(include)
                .FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _context.Set<T>()
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<TT>> All<TT>(Expression<Func<TT, object>> include) where TT : class
        {
            return await _context.Set<TT>()
                .AsNoTracking()
                .Include(include)
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .AsQueryable()
                .Where(predicate)
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<TT>> Find<TT>(Expression<Func<TT, bool>> predicate,
            Expression<Func<TT, object>> include) where TT : class
        {
            return await _context.Set<TT>()
                .AsNoTracking()
                .Where(predicate)
                .Include(include)
                .ToListAsync();
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
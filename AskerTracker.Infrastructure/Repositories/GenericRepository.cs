using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AskerTracker.Infrastructure.Interfaces;

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

        public virtual T Get(Guid id)
        {
            return _context.Find<T>();
        }

        public virtual IEnumerable<T> All()
        {
            return _context.Set<T>()
                .ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
                .AsQueryable()
                .Where(predicate)
                .ToList();
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AskerTracker.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Remove(T entity);
        Task<T> Get(Guid id);
        Task<TT> Get<TT>(Expression<Func<TT, bool>> predicate, Expression<Func<TT, object>> include) where TT : class;
        Task<IEnumerable<T>> All();
        Task<IEnumerable<TT>> All<TT>(Expression<Func<TT, object>> include) where TT : class;
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<TT>> Find<TT>(Expression<Func<TT, bool>> predicate, Expression<Func<TT, object>> include)
            where TT : class;

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
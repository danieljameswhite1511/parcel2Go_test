using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        Task<bool> Save();
        Task<T> GetByIdAsync(int id);
        Task<T> GetFirstOrDefaultByQueryAsync(Expression<Func<T, bool>> query);
        Task<List<T>> ListAllAsync();

        IQueryable<T> ReturnQueryableInclude(params Expression<Func<T, object>> [] includeExpressions);

        IQueryable<T> ReturnQueryableWhereAndInclude(Expression<Func<T, bool>> query, params Expression<Func<T, object>> [] includeExpressions );
    }
}
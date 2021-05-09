using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class GenericRepsository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        public GenericRepsository(DataContext context)
        {
            _context = context;

        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity){

            _context.Set<T>().Remove(entity);
        }

         public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<T> GetFirstOrDefaultByQueryAsync(Expression<Func<T, bool>> query)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(query);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> QueryListAsync(Expression<Func<T, bool>> query)
        {
            return await _context.Set<T>().Where(query).ToListAsync();
        }

         public IQueryable<T> ReturnQueryableInclude(params Expression<Func<T, object>> [] includeExpressions)
        {
            IQueryable<T> set = _context.Set<T>();

                foreach (var includeExpression in includeExpressions)
                {
                  set = set.Include(includeExpression);
                }
            return set;

        }     

          public IQueryable<T> ReturnQueryableWhereAndInclude(Expression<Func<T, bool>> query, params Expression<Func<T, object>> [] includeExpressions )
        {
            IQueryable<T> set = _context.Set<T>().Where(query);

                foreach (var includeExpression in includeExpressions)
                {
                  set = set.Include(includeExpression);
                }
            return set;

        }     

    }
}
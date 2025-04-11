using Core.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public abstract class RepositoryBase<T, R> where R : BaseEntity where T : DbContext
    {
        protected readonly T _context;

        public RepositoryBase(T context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<R>> GetAllAsync(CancellationToken cancellation)
        {
            return await _context.Set<R>().AsNoTracking().ToListAsync(cancellation);
        }

        public virtual async Task<R?> GetByIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await _context.Set<R>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellation);
        }

        public virtual async Task<R?> GetByConditionAsync(Expression<Func<R, bool>> predicate,
            CancellationToken cancellation = default) =>
            await _context.Set<R>().AsNoTracking().FirstOrDefaultAsync(predicate, cancellation);

        public IQueryable<R> GetQueryable(Expression<Func<R, bool>>? predicate = null)
        {
            var query = _context.Set<R>().AsQueryable();
            if (predicate != null) query = query.Where(predicate);
            return query;
        }

        public virtual async Task AddAsync(R entity, CancellationToken cancellation = default)
        {
            await _context.Set<R>().AddAsync(entity, cancellation);
        }

        public virtual Task UpdateAsync(R entity)
        {
            _context.Set<R>().Update(entity);
            return Task.CompletedTask;
        }

        public virtual async Task DeleteAsync(Guid Id, CancellationToken cancellation = default)
        {
            var entity = await GetByIdAsync(Id, cancellation);
            entity.IsDeleted = true;
        }
    }

}

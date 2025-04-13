using Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellation);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellation = default);
        Task<T?> GetByConditionAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellation = default);
        IQueryable<T> GetQueryable(Expression<Func<T, bool>>? predicate = null);
        Task AddAsync(T entity, CancellationToken cancellation = default);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid Id, CancellationToken cancellation = default);
    }

}

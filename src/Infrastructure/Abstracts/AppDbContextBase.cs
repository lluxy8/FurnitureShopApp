using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Abstracts
{
    public abstract class AppDbContextBase : DbContext, IAppDbContext
    {
        private IDbContextTransaction? _transaction;

        protected AppDbContextBase(DbContextOptions options) : base(options)
        {
        }

        public async Task BeginTransactionAsync()
        {
            _transaction ??= await Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction has not been started.");

            try
            {
                await SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }


        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
}

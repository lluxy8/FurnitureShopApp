using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Application.Behaviors
{
    public static class CommandTransactionalMiddleware
    {
        public static async Task BeforeAsync(
            ICommand command,
            WriteDbContext db)
        {
            Console.WriteLine("[Merhaba From CommandTransactionalMiddleware]");
            await db.BeginTransactionAsync();
        }

        public static async Task AfterAsync(
            ICommand command,
            WriteDbContext db)
        {
            await db.CommitTransactionAsync();
        }

        public static async Task FinallyAsync(
            ICommand command,
            WriteDbContext db,
            Exception? ex)
        {
            if (ex != null) await db.RollbackTransactionAsync();
            await db.DisposeAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using Core.Interfaces;
using Infrastructure.Data;

namespace Application.Behaviors
{
    public static class EventTransactionalMiddleware
    {
        public static async Task BeforeAsync(
            IEvent @event,
            ReadDbContext db)
        {
            Console.WriteLine("[Merhaba From EventTransactionalMiddleware]");
            await db.BeginTransactionAsync();
        }

        public static async Task AfterAsync(
            IEvent @event,
            ReadDbContext db)
        {
            await db.CommitTransactionAsync();
        }

        public static async Task FinallyAsync(
            IEvent @event,
            ReadDbContext db,
            Exception? ex)
        {
            if (ex != null) await db.RollbackTransactionAsync();
            await db.DisposeAsync();
        }
    }
}

using Wolverine.Runtime;
using static Wolverine.Runtime.HandlerPipeline;
using Wolverine.Middleware;
using System.Windows.Input;
using Core.Interfaces;
using Wolverine;
using Infrastructure.Data;



namespace Application.Behaviors
{
    public class TransactionBehavior
    {
        private readonly WriteDbContext _writeDb;
        private readonly ReadDbContext _readDb;

        public TransactionBehavior(WriteDbContext writeDb, ReadDbContext readDb)
        {
            _writeDb = writeDb;
            _readDb = readDb;
        }

        public async Task HandleAsync(object message, MessageContext context, Func<Task> next)
        {
            try
            {
                switch (message)
                {
                    case Core.Interfaces.ICommand command:
                        await _writeDb.BeginTransactionAsync();
                        await next(); 
                        await _writeDb.CommitTransactionAsync();  
                        break;

                    case IQuery query:
                        await next();  
                        break;

                    case Core.Interfaces.IEvent @event:
                        await _readDb.BeginTransactionAsync();
                        await next(); 
                        await _readDb.CommitTransactionAsync(); 
                        break;

                    default:
                        throw new InvalidOperationException($"Unsupported message type: {message.GetType().Name}");
                }
            }
            catch (Exception)
            {
                if (message is Core.Interfaces.ICommand)
                {
                    await _writeDb.RollbackTransactionAsync();
                }
                else if (message is Core.Interfaces.IEvent)
                {
                    await _readDb.RollbackTransactionAsync();
                }

                throw; 
            }
            finally
            {
                if (message is Core.Interfaces.ICommand || message is Core.Interfaces.IEvent)
                {
                    await _writeDb.DisposeAsync();
                    await _readDb.DisposeAsync();
                }
            }
        }
    }
}

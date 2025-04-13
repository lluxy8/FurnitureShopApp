using Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using Wolverine;

namespace Application.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddWolverine(opt =>
            {
                opt.Policies.AutoApplyTransactions();
                opt.Durability.Mode = DurabilityMode.MediatorOnly;

                opt.Policies.AddMiddleware<TransactionBehavior>();


            });

            return services;
        }
    }
}

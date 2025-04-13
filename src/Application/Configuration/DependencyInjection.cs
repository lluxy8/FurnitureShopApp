using Application.Behaviors;
using Application.Features.Admin.Commands.Create;
using Core.Entities.Write;
using Infrastructure.Abstracts;
using Infrastructure.Data;
using Infrastructure.Persistence.Repositories;
using JasperFx.Core;
using Microsoft.Extensions.DependencyInjection;
using Wolverine;

namespace Application.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddWolverine(opts =>
            {
                opts.Discovery.IncludeAssembly(typeof(CreateAdmin).Assembly);
                opts.Discovery.IncludeAssembly(typeof(CommandTransactionalMiddleware).Assembly);
                
                opts.Policies
                    .ForMessagesOfType<ICommand>()
                    .AddMiddleware(typeof(CommandTransactionalMiddleware));

                opts.Policies
                    .ForMessagesOfType<IEvent>()
                    .AddMiddleware(typeof(EventTransactionalMiddleware));
                
                opts.PublishMessage<AdminCreated>()
                    .ToLocalQueue("admin-created")
                    .UseDurableInbox();
            });

            return services;
        }
    }
}

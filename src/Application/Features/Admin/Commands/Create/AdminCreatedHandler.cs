using Core.Common.Results;
using Core.Entities.Read;
using Infrastructure.Abstracts;
using Infrastructure.Persistence.Repositories;

namespace Application.Features.Admin.Commands.Create
{
    public static class AdminCreatedHandler
    {
        public static async Task<Result<Guid>> Handle(
            AdminCreated @event,
            IReadRepository<AdminRead> adminRepo,
            CancellationToken cancellationToken)
        {
            await adminRepo.AddAsync(new AdminRead
            {
                Id = @event.Request.Id,
                Username = @event.Request.Username,
                CreateDate = @event.Request.CreateDate,
                IsDeleted = @event.Request.IsDeleted
            }, cancellationToken);

            Console.WriteLine("[Merhaba From AdminCreatedHandler]");
            return Result<Guid>.Success(@event.Request.Id);
        }
    }
}
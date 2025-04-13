using Core.Common.Results;
using Core.Entities.Read;
using Core.Entities.Write;
using Infrastructure.Persistence.Repositories;

namespace Application.Features.Admin.Commands.Create
{
    public class AdminCreatedHandler
    {
        private readonly ReadRepository<AdminRead> _adminRepo;

        public AdminCreatedHandler(ReadRepository<AdminRead> adminRepo)
        {
            _adminRepo = adminRepo;
        }
        public async Task<Result<Guid>> Handle(AdminCreated @event, CancellationToken cancellationToken)
        {
            await _adminRepo.AddAsync(new AdminRead
            {
                Id = @event.Request.Id,
                Username = @event.Request.Username,
                CreateDate = @event.Request.CreateDate,
                IsDeleted = @event.Request.IsDeleted
            }, cancellationToken);


            return Result<Guid>.Success(@event.Request.Id);
        }
    }
}

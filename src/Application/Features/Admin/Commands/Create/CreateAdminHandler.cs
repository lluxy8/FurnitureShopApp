using Core.Common.Helpers;
using Core.Entities.Read;
using Core.Entities.Write;
using Infrastructure.Data;
using Infrastructure.Persistence.Repositories;

namespace Application.Features.Admin.Commands.Create
{
    public class CreateAdminHandler
    {
        private readonly WriteRepository<AdminEntity> _adminRepo;
        private readonly WriteDbContext _writeDb;

        public CreateAdminHandler(WriteRepository<AdminEntity> adminRepo, WriteDbContext writeDb)
        {
            _adminRepo = adminRepo;
            _writeDb = writeDb;
        }

        public async Task<AdminCreated> Handle(CreateAdmin command)
        {
            var Admin = new AdminEntity
            {
                Id = Guid.NewGuid(),
                Username = command.Username,
                PasswordHash = BCryptHelper.HashPassword(command.Password)
            };

            await _adminRepo.AddAsync(Admin);


            return new AdminCreated(
                new AdminRead
                {
                    Id = Admin.Id,
                    Username = Admin.Username,
                    CreateDate = DateTime.UtcNow,
                    IsDeleted = false,
                }
            );
        }
    }
}

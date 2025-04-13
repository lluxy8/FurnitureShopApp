using Core.Common.Helpers;
using Core.Entities.Read;
using Core.Entities.Write;
using Infrastructure.Abstracts;
using Infrastructure.Persistence.Repositories;

namespace Application.Features.Admin.Commands.Create
{
    public static class CreateAdminHandler
    {
        public static async Task<AdminCreated> Handle(
            CreateAdmin command,
            IWriteRepository<AdminEntity> adminRepo) 
        {
            var admin = new AdminEntity
            {
                Id = Guid.NewGuid(),
                Username = command.Username,
                PasswordHash = BCryptHelper.HashPassword(command.Password)
            };

            await adminRepo.AddAsync(admin);

            Console.WriteLine("[Merhaba From CreateAdminHandler]");
            return new AdminCreated(
                new AdminRead
                {
                    Id = admin.Id,
                    Username = admin.Username,
                    CreateDate = DateTime.UtcNow,
                    IsDeleted = false,
                }
            );
        }
    }
}
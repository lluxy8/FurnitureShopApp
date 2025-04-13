using Application.Features.Admin.Commands.Create;
using Core.Common.Results;
using Core.Entities.Write;
using Infrastructure.Data;
using Infrastructure.Persistence.Repositories;
using Moq;

namespace ApplicationTests.Admin
{
    public class CreateAdminTest
    {
        [Fact]
        public async Task CreateAdminHandler_ShouldCreateAdmin()
        {
            // Arrange  
            var mockAdminRepo = new Mock<WriteRepository<AdminEntity>>();
            var mockWriteDb = new Mock<WriteDbContext>();
            var handler = new CreateAdminHandler(mockAdminRepo.Object, mockWriteDb.Object);

            var command = new CreateAdmin("asdfa", "asd");

            // Act  
            var result = await handler.Handle(command);

            // Assert  
            Assert.IsAssignableFrom<IResult>(result);

        }
    }
}

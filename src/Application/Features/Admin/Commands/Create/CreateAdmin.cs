using Core.Interfaces;

namespace Application.Features.Admin.Commands.Create
{
    public record CreateAdmin(string Username, string Password) : ICommand;

}

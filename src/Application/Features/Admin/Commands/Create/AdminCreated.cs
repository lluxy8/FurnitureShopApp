using Core.Entities.Read;
using Core.Interfaces;

namespace Application.Features.Admin.Commands.Create
{
    public record AdminCreated(AdminRead Request) : IEvent;
}

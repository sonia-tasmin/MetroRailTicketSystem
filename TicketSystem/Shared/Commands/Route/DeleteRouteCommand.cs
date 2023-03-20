using MediatR;
using Shared.Security;

namespace Shared.Commands.Route
{
    public class DeleteRouteCommand : IRequest<object>
    {
        public DeleteRouteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}

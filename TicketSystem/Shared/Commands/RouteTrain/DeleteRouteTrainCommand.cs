using MediatR;
using Shared.Security;

namespace Shared.Commands.RouteTrain
{
    public class DeleteRouteTrainCommand : IRequest<object>
    {
        public DeleteRouteTrainCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}

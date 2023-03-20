using MediatR;
using Shared.Security;

namespace Shared.Commands.Route
{
    public class UpdateRouteCommand : IRequest<object>
    {
        public Guid Id { get; set; }
        public string RouteName { get; set; }

    }
}

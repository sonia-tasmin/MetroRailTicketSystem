using MediatR;
using Shared.Security;

namespace Shared.Commands.Route
{
    public class CreateRouteCommand : IRequest<object>
    {

        public string RouteName { get; set; }

    }
}

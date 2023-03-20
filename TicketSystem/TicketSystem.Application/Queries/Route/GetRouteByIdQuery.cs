using MediatR;
using Shared.DTOs.Route;
using Shared.Security;

namespace TicketSystem.Application.Queries.Route
{
    public class GetRouteByIdQuery : IRequest<RouteGetResponseDTO>
    {
        public GetRouteByIdQuery(Guid routeId)
        {
            RouteId = routeId;
        }

        public Guid RouteId { get; private set; }
    }
}

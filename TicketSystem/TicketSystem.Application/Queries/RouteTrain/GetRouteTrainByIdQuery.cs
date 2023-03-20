using MediatR;
using Shared.DTOs.RouteTrain;
using Shared.Security;

namespace TicketSystem.Application.Queries.RouteTrain
{
    public class GetRouteTrainByIdQuery : IRequest<RouteTrainGetResponseDTO>
    {
        public GetRouteTrainByIdQuery(Guid routeTrainId)
        {
            RouteTrainId = routeTrainId;
        }

        public Guid RouteTrainId { get; private set; }
    }
}

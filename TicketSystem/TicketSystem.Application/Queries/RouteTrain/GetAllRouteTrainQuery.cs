using MediatR;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.RouteTrain;
using Shared.Security;

namespace TicketSystem.Application.Queries.RouteTrain
{
    public class GetAllRouteTrainQuery : IRequest<IEnumerable<RouteTrainGetResponseDTO>>
    {

    }
}

using MediatR;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.Route;
using Shared.Security;

namespace TicketSystem.Application.Queries.Route
{
    public class GetAllRouteQuery : IRequest<IEnumerable<RouteGetResponseDTO>>
    {

    }
}

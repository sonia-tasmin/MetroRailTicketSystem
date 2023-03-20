using MediatR;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.Order;
using Shared.Security;

namespace TicketSystem.Application.Queries.Order
{
    public class GetAllOrderQuery : IRequest<IEnumerable<OrderGetResponseDTO>>
    {

    }
}

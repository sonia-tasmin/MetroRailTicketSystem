using MediatR;
using Shared.DTOs.Order;
using Shared.Security;

namespace TicketSystem.Application.Queries.Order
{
    public class GetOrderByIdQuery : IRequest<OrderGetResponseDTO>
    {
        public GetOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; private set; }
    }
}

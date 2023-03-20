using MediatR;
using Shared.Security;

namespace Shared.Commands.Order
{
    public class UpdateOrderCommand : IRequest<object>
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Guid SeatId { get; set; }
        public string SeatName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Returned { get; set; }

    }
}

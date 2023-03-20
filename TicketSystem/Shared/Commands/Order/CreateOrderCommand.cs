using MediatR;
using Shared.Security;

namespace Shared.Commands.Order
{
    public class CreateOrderCommand : IRequest<object>
    {

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid SeatId { get; set; }
        public string SeatName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Returned { get; set; }


    }
}

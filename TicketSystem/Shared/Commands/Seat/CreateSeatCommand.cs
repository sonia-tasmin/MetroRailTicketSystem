using MediatR;
using Shared.Security;

namespace Shared.Commands.Seat
{
    public class CreateSeatCommand : IRequest<object>
    {

        public string SeatName { get; set; }
        public float Price { get; set; }
        public bool Ordered { get; set; }
        public Guid RouteTrainId { get; set; }


    }
}

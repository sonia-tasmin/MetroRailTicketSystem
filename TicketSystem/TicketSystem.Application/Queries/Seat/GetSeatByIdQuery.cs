using MediatR;
using Shared.DTOs.Seat;
using Shared.Security;

namespace TicketSystem.Application.Queries.Seat
{
    public class GetSeatByIdQuery : IRequest<SeatGetResponseDTO>
    {
        public GetSeatByIdQuery(Guid seatId)
        {
            SeatId = seatId;
        }

        public Guid SeatId { get; private set; }
    }
}

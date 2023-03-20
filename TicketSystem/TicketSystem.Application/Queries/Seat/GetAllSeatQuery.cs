using MediatR;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.Seat;
using Shared.Security;

namespace TicketSystem.Application.Queries.Seat
{
    public class GetAllSeatQuery : IRequest<IEnumerable<SeatGetResponseDTO>>
    {

    }
}

using MediatR;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.Train;
using Shared.Security;

namespace TicketSystem.Application.Queries.Train
{
    public class GetAllTrainQuery : IRequest<IEnumerable<TrainGetResponseDTO>>
    {

    }
}

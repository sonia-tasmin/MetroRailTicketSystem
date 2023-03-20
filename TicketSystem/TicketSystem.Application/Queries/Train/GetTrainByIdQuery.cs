using MediatR;
using Shared.DTOs.Train;
using Shared.Security;

namespace TicketSystem.Application.Queries.Train
{
    public class GetTrainByIdQuery : IRequest<TrainGetResponseDTO>
    {
        public GetTrainByIdQuery(Guid trainId)
        {
            TrainId = trainId;
        }

        public Guid TrainId { get; private set; }
    }
}

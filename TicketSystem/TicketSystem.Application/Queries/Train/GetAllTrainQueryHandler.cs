using AutoMapper;
using MediatR;
using TicketSystem.Application.Contracts.Repositories.Query;

using Shared.DTOs.Train;

namespace TicketSystem.Application.Queries.Train
{
    public class GetAllTrainQueryHandler : IRequestHandler<GetAllTrainQuery, IEnumerable<TrainGetResponseDTO>>
    {
        private readonly ITrainQueryRepository _TrainQueryRepository;
        private readonly IMapper _mapper;
        public GetAllTrainQueryHandler(ITrainQueryRepository trainQueryRepository, IMapper mapper)
        {
            _TrainQueryRepository = trainQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TrainGetResponseDTO>> Handle(GetAllTrainQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Core.Entities.Train>, IEnumerable<TrainGetResponseDTO>>(await _TrainQueryRepository.GetAll(request));
        }
    }
}

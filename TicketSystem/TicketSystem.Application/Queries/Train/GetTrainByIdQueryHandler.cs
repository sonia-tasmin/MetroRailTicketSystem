using AutoMapper;
using MediatR;
using TicketSystem.Application.Contracts.Repositories.Query;
using Shared.DTOs.Train;

namespace TicketSystem.Application.Queries.Train
{
    internal class GetTrainByIdQueryHandler : IRequestHandler<GetTrainByIdQuery, TrainGetResponseDTO>
    {
        private readonly ITrainQueryRepository _TrainQueryRepository;
        private readonly IMapper _mapper;
        public GetTrainByIdQueryHandler(ITrainQueryRepository TrainQueryRepository, IMapper mapper)
        {
            _TrainQueryRepository = TrainQueryRepository;
            _mapper = mapper;
        }

        public async Task<TrainGetResponseDTO> Handle(GetTrainByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Core.Entities.Train, TrainGetResponseDTO>(await _TrainQueryRepository.GetById(request.TrainId));
        }
    }
}

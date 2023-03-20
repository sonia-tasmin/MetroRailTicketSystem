using AutoMapper;
using MediatR;
using TicketSystem.Application.Contracts.Repositories.Query;
using Shared.DTOs.RouteTrain;

namespace TicketSystem.Application.Queries.RouteTrain
{
    internal class GetRouteTrainByIdQueryHandler : IRequestHandler<GetRouteTrainByIdQuery, RouteTrainGetResponseDTO>
    {
        private readonly IRouteTrainQueryRepository _RouteTrainQueryRepository;
        private readonly IMapper _mapper;
        public GetRouteTrainByIdQueryHandler(IRouteTrainQueryRepository RouteTrainQueryRepository, IMapper mapper)
        {
            _RouteTrainQueryRepository = RouteTrainQueryRepository;
            _mapper = mapper;
        }

        public async Task<RouteTrainGetResponseDTO> Handle(GetRouteTrainByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Core.Entities.RouteTrain, RouteTrainGetResponseDTO>(await _RouteTrainQueryRepository.GetById(request.RouteTrainId));
        }
    }
}

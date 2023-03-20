using AutoMapper;
using MediatR;
using TicketSystem.Application.Contracts.Repositories.Query;

using Shared.DTOs.RouteTrain;

namespace TicketSystem.Application.Queries.RouteTrain
{
    public class GetAllRouteTrainQueryHandler : IRequestHandler<GetAllRouteTrainQuery, IEnumerable<RouteTrainGetResponseDTO>>
    {
        private readonly IRouteTrainQueryRepository _RouteTrainQueryRepository;
        private readonly IMapper _mapper;
        public GetAllRouteTrainQueryHandler(IRouteTrainQueryRepository routeTrainQueryRepository, IMapper mapper)
        {
            _RouteTrainQueryRepository = routeTrainQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RouteTrainGetResponseDTO>> Handle(GetAllRouteTrainQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Core.Entities.RouteTrain>, IEnumerable<RouteTrainGetResponseDTO>>(await _RouteTrainQueryRepository.GetAll(request));
        }
    }
}

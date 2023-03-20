using AutoMapper;
using MediatR;
using TicketSystem.Application.Contracts.Repositories.Query;

using Shared.DTOs.Route;

namespace TicketSystem.Application.Queries.Route
{
    public class GetAllRouteQueryHandler : IRequestHandler<GetAllRouteQuery, IEnumerable<RouteGetResponseDTO>>
    {
        private readonly IRouteQueryRepository _RouteQueryRepository;
        private readonly IMapper _mapper;
        public GetAllRouteQueryHandler(IRouteQueryRepository routeQueryRepository, IMapper mapper)
        {
            _RouteQueryRepository = routeQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RouteGetResponseDTO>> Handle(GetAllRouteQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Core.Entities.Route>, IEnumerable<RouteGetResponseDTO>>(await _RouteQueryRepository.GetAll(request));
        }
    }
}

using AutoMapper;
using MediatR;
using TicketSystem.Application.Contracts.Repositories.Query;
using Shared.DTOs.Route;

namespace TicketSystem.Application.Queries.Route
{
    internal class GetRouteByIdQueryHandler : IRequestHandler<GetRouteByIdQuery, RouteGetResponseDTO>
    {
        private readonly IRouteQueryRepository _RouteQueryRepository;
        private readonly IMapper _mapper;
        public GetRouteByIdQueryHandler(IRouteQueryRepository RouteQueryRepository, IMapper mapper)
        {
            _RouteQueryRepository = RouteQueryRepository;
            _mapper = mapper;
        }

        public async Task<RouteGetResponseDTO> Handle(GetRouteByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Core.Entities.Route, RouteGetResponseDTO>(await _RouteQueryRepository.GetById(request.RouteId));
        }
    }
}

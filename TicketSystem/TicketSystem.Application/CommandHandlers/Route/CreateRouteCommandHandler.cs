using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.Route;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.Route;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.Route
{
    public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IRouteCommandRepository _routeCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRouteCommandHandler(IMapper mapper, IRouteCommandRepository routeCommandRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _routeCommandRepository = routeCommandRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<object> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            var route = _mapper.Map<CreateRouteCommand, Core.Entities.Route>(request);
            var result = await _routeCommandRepository.InsertAsync(route);
            var affectedRows = await _unitOfWork.CommitAsync();
            var RouteAddResponse = new BasePostResponseDTO<Guid, RoutePostResponseDTO> { Id = route.Id, Success = affectedRows > 0, Message = affectedRows > 0 ? "Route created successfully" : "Something went wrong.Please try again", Entity = _mapper.Map<Core.Entities.Route, RoutePostResponseDTO>(result) };


            return RouteAddResponse;
        }
    }
}

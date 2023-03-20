using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.Route;
using TicketSystem.Application.Common.Exceptions;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.Route;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.Route
{
    internal class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IRouteCommandRepository _routeCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRouteCommandHandler(IMapper mapper, IRouteCommandRepository routeCommandRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _routeCommandRepository = routeCommandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<object> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {
            var routeEntity = await _routeCommandRepository.GetAsync(request.Id);
            if (routeEntity == null)
                throw new NotFoundException("Invalid id");
            var mappedRoute = _mapper.Map(request, routeEntity);
            var result = await _routeCommandRepository.UpdateAsync(mappedRoute);
            var affectedRows = await _unitOfWork.CommitAsync();
            var routeUpdateResponse = new BasePostResponseDTO<Guid, RoutePostResponseDTO> { Id = routeEntity.Id, Success = affectedRows > 0, Message = affectedRows > 0 ? "Route updated successfully" : "Something went wrong.Please try again", Entity = _mapper.Map<Core.Entities.Route, RoutePostResponseDTO>(result) };

            return routeUpdateResponse;
        }
    }
}

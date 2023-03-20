using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.RouteTrain;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.RouteTrain;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.RouteTrain
{
    public class CreateRouteTrainCommandHandler : IRequestHandler<CreateRouteTrainCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IRouteTrainCommandRepository _routeTrainCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRouteTrainCommandHandler(IMapper mapper, IRouteTrainCommandRepository routeTrainCommandRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _routeTrainCommandRepository = routeTrainCommandRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<object> Handle(CreateRouteTrainCommand request, CancellationToken cancellationToken)
        {
            var routeTrain = _mapper.Map<CreateRouteTrainCommand, Core.Entities.RouteTrain>(request);
            var result = await _routeTrainCommandRepository.InsertAsync(routeTrain);
            var affectedRows = await _unitOfWork.CommitAsync();
            var RouteTrainAddResponse = new BasePostResponseDTO<Guid, RouteTrainPostResponseDTO> { Id = routeTrain.Id, Success = affectedRows > 0, Message = affectedRows > 0 ? "RouteTrain created successfully" : "Something went wrong.Please try again", Entity = _mapper.Map<Core.Entities.RouteTrain, RouteTrainPostResponseDTO>(result) };


            return RouteTrainAddResponse;
        }
    }
}

using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.RouteTrain;
using TicketSystem.Application.Common.Exceptions;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.RouteTrain;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.RouteTrain
{
    internal class UpdateRouteTrainCommandHandler : IRequestHandler<UpdateRouteTrainCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IRouteTrainCommandRepository _routeTrainCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRouteTrainCommandHandler(IMapper mapper, IRouteTrainCommandRepository routeTrainCommandRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _routeTrainCommandRepository = routeTrainCommandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<object> Handle(UpdateRouteTrainCommand request, CancellationToken cancellationToken)
        {
            var routeTrainEntity = await _routeTrainCommandRepository.GetAsync(request.Id);
            if (routeTrainEntity == null)
                throw new NotFoundException("Invalid id");
            var mappedRouteTrain = _mapper.Map(request, routeTrainEntity);
            var result = await _routeTrainCommandRepository.UpdateAsync(mappedRouteTrain);
            var affectedRows = await _unitOfWork.CommitAsync();
            var routeTrainUpdateResponse = new BasePostResponseDTO<Guid, RouteTrainPostResponseDTO> { Id = routeTrainEntity.Id, Success = affectedRows > 0, Message = affectedRows > 0 ? "RouteTrain updated successfully" : "Something went wrong.Please try again", Entity = _mapper.Map<Core.Entities.RouteTrain, RouteTrainPostResponseDTO>(result) };

            return routeTrainUpdateResponse;
        }
    }
}

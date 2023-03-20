using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.RouteTrain;
using TicketSystem.Application.Common.Exceptions;
using TicketSystem.Application.Queries.RouteTrain;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.RouteTrain
{
    public class DeleteRouteTrainCommandHandler : IRequestHandler<DeleteRouteTrainCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IRouteTrainCommandRepository _routeTrainCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRouteTrainCommandHandler(IMapper mapper, IRouteTrainCommandRepository routeTrainCommandRepository, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _routeTrainCommandRepository = routeTrainCommandRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<object> Handle(DeleteRouteTrainCommand request, CancellationToken cancellationToken)
        {
            var RouteTrain = await _mediator.Send(new GetRouteTrainByIdQuery(request.Id));
            if (RouteTrain == null)
            {
                throw new NotFoundException("No RouteTrain information found");
            }

            var RouteTrainEntity = _mapper.Map<Core.Entities.RouteTrain>(RouteTrain);
            //SeatEntity.IsDeleted = true;
            await _routeTrainCommandRepository.UpdateAsync(RouteTrainEntity);
            await _unitOfWork.CommitAsync();
            return "RouteTrain information has been deleted!";
        }
    }
}

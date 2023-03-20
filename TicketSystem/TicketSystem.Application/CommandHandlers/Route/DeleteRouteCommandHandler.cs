using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.Route;
using TicketSystem.Application.Common.Exceptions;
using TicketSystem.Application.Queries.Route;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.Route
{
    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IRouteCommandRepository _routeCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRouteCommandHandler(IMapper mapper, IRouteCommandRepository routeCommandRepository, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _routeCommandRepository = routeCommandRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<object> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            var Route = await _mediator.Send(new GetRouteByIdQuery(request.Id));
            if (Route == null)
            {
                throw new NotFoundException("No Route information found");
            }

            var RouteEntity = _mapper.Map<Core.Entities.Route>(Route);
            await _routeCommandRepository.UpdateAsync(RouteEntity);
            await _unitOfWork.CommitAsync();
            return "Route information has been deleted!";
        }
    }
}

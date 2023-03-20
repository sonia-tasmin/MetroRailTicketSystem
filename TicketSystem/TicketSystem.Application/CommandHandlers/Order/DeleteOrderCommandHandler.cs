using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.Order;
using TicketSystem.Application.Common.Exceptions;
using TicketSystem.Application.Queries.Order;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.Order
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IOrderCommandRepository _orderCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(IMapper mapper, IOrderCommandRepository orderCommandRepository, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _orderCommandRepository = orderCommandRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<object> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var Order = await _mediator.Send(new GetOrderByIdQuery(request.Id));
            if (Order == null)
            {
                throw new NotFoundException("No Order information found");
            }

            var OrderEntity = _mapper.Map<Core.Entities.Order>(Order);
            await _orderCommandRepository.UpdateAsync(OrderEntity);
            await _unitOfWork.CommitAsync();
            return "Order information has been deleted!";
        }
    }
}

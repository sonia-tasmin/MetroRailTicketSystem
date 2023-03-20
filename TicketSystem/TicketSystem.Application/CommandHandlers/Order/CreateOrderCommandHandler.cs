using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.Order;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.Order;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.Order
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IOrderCommandRepository _orderCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IMapper mapper, IOrderCommandRepository orderCommandRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _orderCommandRepository = orderCommandRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<object> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<CreateOrderCommand, Core.Entities.Order>(request);
            var result = await _orderCommandRepository.InsertAsync(order);
            var affectedRows = await _unitOfWork.CommitAsync();
            var OrderAddResponse = new BasePostResponseDTO<Guid, OrderPostResponseDTO> { Id = order.Id, Success = affectedRows > 0, Message = affectedRows > 0 ? "Order created successfully" : "Something went wrong.Please try again", Entity = _mapper.Map<Core.Entities.Order, OrderPostResponseDTO>(result) };


            return OrderAddResponse;
        }
    }
}

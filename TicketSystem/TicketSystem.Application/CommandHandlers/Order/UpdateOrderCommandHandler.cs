using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.Order;
using TicketSystem.Application.Common.Exceptions;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.Order;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.Order
{
    internal class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IOrderCommandRepository _orderCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderCommandHandler(IMapper mapper, IOrderCommandRepository orderCommandRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _orderCommandRepository = orderCommandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<object> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = await _orderCommandRepository.GetAsync(request.Id);
            if (orderEntity == null)
                throw new NotFoundException("Invalid id");
            var mappedOrder = _mapper.Map(request, orderEntity);
            var result = await _orderCommandRepository.UpdateAsync(mappedOrder);
            var affectedRows = await _unitOfWork.CommitAsync();
            var orderUpdateResponse = new BasePostResponseDTO<Guid, OrderPostResponseDTO> { Id = orderEntity.Id, Success = affectedRows > 0, Message = affectedRows > 0 ? "Order updated successfully" : "Something went wrong.Please try again", Entity = _mapper.Map<Core.Entities.Order, OrderPostResponseDTO>(result) };

            return orderUpdateResponse;
        }
    }
}

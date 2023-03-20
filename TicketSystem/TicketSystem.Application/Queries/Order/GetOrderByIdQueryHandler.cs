using AutoMapper;
using MediatR;
using TicketSystem.Application.Contracts.Repositories.Query;
using Shared.DTOs.Order;
using TicketSystem.Application.Queries.Order;
using Shared.DTOs.Order;

namespace TicketSystem.Application.Queries.Order
{
    internal class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderGetResponseDTO>
    {
        private readonly IOrderQueryRepository _OrderQueryRepository;
        private readonly IMapper _mapper;
        public GetOrderByIdQueryHandler(IOrderQueryRepository OrderQueryRepository, IMapper mapper)
        {
            _OrderQueryRepository = OrderQueryRepository;
            _mapper = mapper;
        }

        public async Task<OrderGetResponseDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Core.Entities.Order, OrderGetResponseDTO>(await _OrderQueryRepository.GetById(request.OrderId));
        }
    }
}

using AutoMapper;
using MediatR;
using TicketSystem.Application.Contracts.Repositories.Query;

using Shared.DTOs.Order;
using TicketSystem.Application.Queries.Order;

namespace TicketSystem.Application.Queries.Order
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<OrderGetResponseDTO>>
    {
        private readonly IOrderQueryRepository _OrderQueryRepository;
        private readonly IMapper _mapper;
        public GetAllOrderQueryHandler(IOrderQueryRepository orderQueryRepository, IMapper mapper)
        {
            _OrderQueryRepository = orderQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderGetResponseDTO>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Core.Entities.Order>, IEnumerable<OrderGetResponseDTO>>(await _OrderQueryRepository.GetAll(request));
        }
    }
}

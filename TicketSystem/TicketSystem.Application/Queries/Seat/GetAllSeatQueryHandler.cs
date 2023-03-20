using AutoMapper;
using MediatR;
using TicketSystem.Application.Contracts.Repositories.Query;

using Shared.DTOs.Seat;

namespace TicketSystem.Application.Queries.Seat
{
    public class GetAllSeatQueryHandler : IRequestHandler<GetAllSeatQuery, IEnumerable<SeatGetResponseDTO>>
    {
        private readonly ISeatQueryRepository _SeatQueryRepository;
        private readonly IMapper _mapper;
        public GetAllSeatQueryHandler(ISeatQueryRepository seatQueryRepository, IMapper mapper)
        {
            _SeatQueryRepository = seatQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SeatGetResponseDTO>> Handle(GetAllSeatQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Core.Entities.Seat>, IEnumerable<SeatGetResponseDTO>>(await _SeatQueryRepository.GetAll(request));
        }
    }
}

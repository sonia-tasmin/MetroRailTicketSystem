using AutoMapper;
using MediatR;
using TicketSystem.Application.Contracts.Repositories.Query;
using Shared.DTOs.Seat;

namespace TicketSystem.Application.Queries.Seat
{
    internal class GetSeatByIdQueryHandler : IRequestHandler<GetSeatByIdQuery, SeatGetResponseDTO>
    {
        private readonly ISeatQueryRepository _SeatQueryRepository;
        private readonly IMapper _mapper;
        public GetSeatByIdQueryHandler(ISeatQueryRepository SeatQueryRepository, IMapper mapper)
        {
            _SeatQueryRepository = SeatQueryRepository;
            _mapper = mapper;
        }

        public async Task<SeatGetResponseDTO> Handle(GetSeatByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Core.Entities.Seat, SeatGetResponseDTO>(await _SeatQueryRepository.GetById(request.SeatId));
        }
    }
}

using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.Seat;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.Seat;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.Seat
{
    public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly ISeatCommandRepository _seatCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSeatCommandHandler(IMapper mapper, ISeatCommandRepository seatCommandRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _seatCommandRepository = seatCommandRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<object> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            var seat = _mapper.Map<CreateSeatCommand, Core.Entities.Seat>(request);
            var result = await _seatCommandRepository.InsertAsync(seat);
            var affectedRows = await _unitOfWork.CommitAsync();
            var SeatAddResponse = new BasePostResponseDTO<Guid, SeatPostResponseDTO> { Id = seat.Id, Success = affectedRows > 0, Message = affectedRows > 0 ? "Seat created successfully" : "Something went wrong.Please try again", Entity = _mapper.Map<Core.Entities.Seat, SeatPostResponseDTO>(result) };


            return SeatAddResponse;
        }
    }
}

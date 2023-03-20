using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.Seat;
using TicketSystem.Application.Common.Exceptions;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.Seat;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.Seat
{
    internal class UpdateSeatCommandHandler : IRequestHandler<UpdateSeatCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly ISeatCommandRepository _seatCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSeatCommandHandler(IMapper mapper, ISeatCommandRepository seatCommandRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _seatCommandRepository = seatCommandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<object> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            var seatEntity = await _seatCommandRepository.GetAsync(request.Id);
            if (seatEntity == null)
                throw new NotFoundException("Invalid id");
            var mappedSeat = _mapper.Map(request, seatEntity);
            var result = await _seatCommandRepository.UpdateAsync(mappedSeat);
            var affectedRows = await _unitOfWork.CommitAsync();
            var seatUpdateResponse = new BasePostResponseDTO<Guid, SeatPostResponseDTO> { Id = seatEntity.Id, Success = affectedRows > 0, Message = affectedRows > 0 ? "Seat updated successfully" : "Something went wrong.Please try again", Entity = _mapper.Map<Core.Entities.Seat, SeatPostResponseDTO>(result) };

            return seatUpdateResponse;
        }
    }
}

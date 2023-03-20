using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.Seat;
using TicketSystem.Application.Common.Exceptions;
using TicketSystem.Application.Queries.Seat;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.Seat
{
    public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ISeatCommandRepository _seatCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSeatCommandHandler(IMapper mapper, ISeatCommandRepository seatCommandRepository, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _seatCommandRepository = seatCommandRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<object> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            var Seat = await _mediator.Send(new GetSeatByIdQuery(request.Id));
            if (Seat == null)
            {
                throw new NotFoundException("No Seat information found");
            }

            var SeatEntity = _mapper.Map<Core.Entities.Seat>(Seat);
            //SeatEntity.IsDeleted = true;
            await _seatCommandRepository.UpdateAsync(SeatEntity);
            await _unitOfWork.CommitAsync();
            return "Seat information has been deleted!";
        }
    }
}

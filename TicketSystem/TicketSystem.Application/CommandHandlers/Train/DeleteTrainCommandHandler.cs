using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.Train;
using TicketSystem.Application.Common.Exceptions;
using TicketSystem.Application.Queries.Train;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.Train
{
    public class DeleteTrainCommandHandler : IRequestHandler<DeleteTrainCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ITrainCommandRepository _trainCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTrainCommandHandler(IMapper mapper, ITrainCommandRepository trainCommandRepository, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _trainCommandRepository = trainCommandRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<object> Handle(DeleteTrainCommand request, CancellationToken cancellationToken)
        {
            var Train = await _mediator.Send(new GetTrainByIdQuery(request.Id));
            if (Train == null)
            {
                throw new NotFoundException("No Train information found");
            }

            var TrainEntity = _mapper.Map<Core.Entities.Train>(Train);
            await _trainCommandRepository.UpdateAsync(TrainEntity);
            await _unitOfWork.CommitAsync();
            return "Train information has been deleted!";
        }
    }
}

using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.Train;
using TicketSystem.Application.Common.Exceptions;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.Train;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.Train
{
    internal class UpdateTrainCommandHandler : IRequestHandler<UpdateTrainCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly ITrainCommandRepository _trainCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTrainCommandHandler(IMapper mapper, ITrainCommandRepository trainCommandRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _trainCommandRepository = trainCommandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<object> Handle(UpdateTrainCommand request, CancellationToken cancellationToken)
        {
            var trainEntity = await _trainCommandRepository.GetAsync(request.Id);
            if (trainEntity == null)
                throw new NotFoundException("Invalid id");
            var mappedTrain = _mapper.Map(request, trainEntity);
            var result = await _trainCommandRepository.UpdateAsync(mappedTrain);
            var affectedRows = await _unitOfWork.CommitAsync();
            var trainUpdateResponse = new BasePostResponseDTO<Guid, TrainPostResponseDTO> { Id = trainEntity.Id, Success = affectedRows > 0, Message = affectedRows > 0 ? "Train updated successfully" : "Something went wrong.Please try again", Entity = _mapper.Map<Core.Entities.Train, TrainPostResponseDTO>(result) };

            return trainUpdateResponse;
        }
    }
}

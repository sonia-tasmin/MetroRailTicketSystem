using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.Train;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.Train;
using AutoMapper;
using MediatR;
using System.Diagnostics;

namespace TicketSystem.Application.CommandHandlers.Train
{
    public class CreateTrainCommandHandler : IRequestHandler<CreateTrainCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly ITrainCommandRepository _trainCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTrainCommandHandler(IMapper mapper, ITrainCommandRepository trainCommandRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _trainCommandRepository = trainCommandRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<object> Handle(CreateTrainCommand request, CancellationToken cancellationToken)
        {
            var train = _mapper.Map<CreateTrainCommand, Core.Entities.Train>(request);
            var result = await _trainCommandRepository.InsertAsync(train);
            var affectedRows = await _unitOfWork.CommitAsync();
            var TrainAddResponse = new BasePostResponseDTO<Guid, TrainPostResponseDTO> { Id = train.Id, Success = affectedRows > 0, Message = affectedRows > 0 ? "Train created successfully" : "Something went wrong.Please try again", Entity = _mapper.Map<Core.Entities.Train, TrainPostResponseDTO>(result) };


            return TrainAddResponse;
        }
    }
}

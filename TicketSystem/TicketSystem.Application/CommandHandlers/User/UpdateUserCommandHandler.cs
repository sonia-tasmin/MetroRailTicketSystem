using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.User;
using TicketSystem.Application.Common.Exceptions;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.User;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.User
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IMapper mapper, IUserCommandRepository userCommandRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userCommandRepository = userCommandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<object> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = await _userCommandRepository.GetAsync(request.Id);
            if (userEntity == null)
                throw new NotFoundException("Invalid id");
            var mappedUser = _mapper.Map(request, userEntity);
            var result = await _userCommandRepository.UpdateAsync(mappedUser);
            var affectedRows = await _unitOfWork.CommitAsync();
            var userUpdateResponse = new BasePostResponseDTO<Guid, UserPostResponseDTO> { Id = userEntity.Id, Success = affectedRows > 0, Message = affectedRows > 0 ? "User updated successfully" : "Something went wrong.Please try again", Entity = _mapper.Map<Core.Entities.User, UserPostResponseDTO>(result) };

            return userUpdateResponse;
        }
    }
}

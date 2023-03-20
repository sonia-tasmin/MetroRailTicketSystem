using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.User;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.User;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IMapper mapper, IUserCommandRepository userCommandRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userCommandRepository = userCommandRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<object> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<CreateUserCommand, Core.Entities.User>(request);
            var result = await _userCommandRepository.InsertAsync(user);
            var affectedRows = await _unitOfWork.CommitAsync();
            var UserAddResponse = new BasePostResponseDTO<Guid, UserPostResponseDTO> { Id = user.Id, Success = affectedRows > 0, Message = affectedRows > 0 ? "User created successfully" : "Something went wrong.Please try again", Entity = _mapper.Map<Core.Entities.User, UserPostResponseDTO>(result) };


            return UserAddResponse;
        }
    }
}

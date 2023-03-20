using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories;
using Shared.Commands.User;
using TicketSystem.Application.Common.Exceptions;
using TicketSystem.Application.Queries.User;
using AutoMapper;
using MediatR;

namespace TicketSystem.Application.CommandHandlers.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, object>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IMapper mapper, IUserCommandRepository userCommandRepository, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userCommandRepository = userCommandRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<object> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var User = await _mediator.Send(new GetUserByIdQuery(request.Id));
            if (User == null)
            {
                throw new NotFoundException("No User information found");
            }

            var UserEntity = _mapper.Map<Core.Entities.User>(User);
            await _userCommandRepository.UpdateAsync(UserEntity);
            await _unitOfWork.CommitAsync();
            return "User information has been deleted!";
        }
    }
}

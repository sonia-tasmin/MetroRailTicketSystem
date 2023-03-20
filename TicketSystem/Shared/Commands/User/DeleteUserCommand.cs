using MediatR;
using Shared.Security;

namespace Shared.Commands.User
{
    public class DeleteUserCommand : IRequest<object>
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}

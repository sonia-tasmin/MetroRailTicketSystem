using MediatR;
using Shared.Security;

namespace Shared.Commands.Seat
{
    public class DeleteSeatCommand : IRequest<object>
    {
        public DeleteSeatCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}

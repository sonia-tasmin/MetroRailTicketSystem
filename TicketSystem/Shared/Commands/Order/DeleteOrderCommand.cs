using MediatR;
using Shared.Security;

namespace Shared.Commands.Order
{
    public class DeleteOrderCommand : IRequest<object>
    {
        public DeleteOrderCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}

using MediatR;
using Shared.Security;

namespace Shared.Commands.Train
{
    public class DeleteTrainCommand : IRequest<object>
    {
        public DeleteTrainCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}

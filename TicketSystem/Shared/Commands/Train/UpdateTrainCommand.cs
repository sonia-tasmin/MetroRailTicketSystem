using MediatR;
using Shared.Security;

namespace Shared.Commands.Train
{
    public class UpdateTrainCommand : IRequest<object>
    {
        public Guid Id { get; set; }
        public string TrainName { get; set; }

    }
}

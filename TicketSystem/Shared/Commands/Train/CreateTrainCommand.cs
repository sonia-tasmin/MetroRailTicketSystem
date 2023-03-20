using MediatR;
using Shared.Security;

namespace Shared.Commands.Train
{
    public class CreateTrainCommand : IRequest<object>
    {
        public string TrainName { get; set; }


    }
}

using MediatR;
using Shared.Security;

namespace Shared.Commands.RouteTrain
{
    public class CreateRouteTrainCommand : IRequest<object>
    {
        public Guid TrainId { get; set; }
        public string TrainName { get; set; }
        public Guid RouteId { get; set; }
        public string RouteName { get; set; }
        public bool Active { get; set; }
    }
}

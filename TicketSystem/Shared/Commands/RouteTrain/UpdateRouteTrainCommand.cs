using MediatR;
using Shared.Security;

namespace Shared.Commands.RouteTrain
{
    public class UpdateRouteTrainCommand : IRequest<object>
    {
        public Guid Id { get; set; }
        public Guid TrainId { get; set; }
        public string TrainName { get; set; }
        public Guid RouteId { get; set; }
        public string RouteName { get; set; }
        public bool Active { get; set; }
    }
}

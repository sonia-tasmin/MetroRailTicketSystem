using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Core.Entities;
using TicketSystem.Infrastructure.Persistence;
using TicketSystem.Infrastructure.Repository.Command.Base;


namespace TicketSystem.Infrastructure.Repository.Command
{
    public class RouteTrainCommandRepository : CommandRepository<RouteTrain>, IRouteTrainCommandRepository
    {
        public RouteTrainCommandRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

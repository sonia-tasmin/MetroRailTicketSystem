using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Core.Entities;
using TicketSystem.Infrastructure.Persistence;
using TicketSystem.Infrastructure.Repository.Command.Base;


namespace TicketSystem.Infrastructure.Repository.Command
{
    public class OrderCommandRepository : CommandRepository<Order>, IOrderCommandRepository
    {
        public OrderCommandRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

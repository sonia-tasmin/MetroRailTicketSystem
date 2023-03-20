using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Core.Entities;
using TicketSystem.Infrastructure.Persistence;
using TicketSystem.Infrastructure.Repository.Command.Base;


namespace TicketSystem.Infrastructure.Repository.Command
{
    public class UserCommandRepository : CommandRepository<User>, IUserCommandRepository
    {
        public UserCommandRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

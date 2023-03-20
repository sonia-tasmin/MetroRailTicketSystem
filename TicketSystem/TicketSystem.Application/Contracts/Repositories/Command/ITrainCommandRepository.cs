using TicketSystem.Application.Contracts.Repositories.Command.Base;
using TicketSystem.Core.Entities;

namespace TicketSystem.Application.Contracts.Repositories.Command
{
    public interface ITrainCommandRepository : ICommandRepository<Train>
    {
    }
}

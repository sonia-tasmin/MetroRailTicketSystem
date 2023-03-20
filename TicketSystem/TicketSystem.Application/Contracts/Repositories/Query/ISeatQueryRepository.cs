using TicketSystem.Application.Contracts.Repositories.Query.Base;
using TicketSystem.Application.Queries.Seat;
using TicketSystem.Core.Entities;
using Shared.DTOs.Base;

namespace TicketSystem.Application.Contracts.Repositories.Query
{
    public interface ISeatQueryRepository : IMultipleResultQueryRepository<Seat>
    {
        Task<IEnumerable<Seat>> GetAll(GetAllSeatQuery getSeatQuery);
        Task<Seat> GetById(Guid Id);
    }
}

using TicketSystem.Application.Contracts.Repositories.Query.Base;
using TicketSystem.Application.Queries.Route;
using TicketSystem.Core.Entities;
using Shared.DTOs.Base;

namespace TicketSystem.Application.Contracts.Repositories.Query
{
    public interface IRouteQueryRepository : IMultipleResultQueryRepository<Route>
    {
        Task<IEnumerable<Route>> GetAll(GetAllRouteQuery getRouteQuery);
        Task<Route> GetById(Guid Id);
    }
}

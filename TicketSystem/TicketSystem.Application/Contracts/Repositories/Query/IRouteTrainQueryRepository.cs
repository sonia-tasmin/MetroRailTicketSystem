using TicketSystem.Application.Contracts.Repositories.Query.Base;
using TicketSystem.Application.Queries.RouteTrain;
using TicketSystem.Core.Entities;
using Shared.DTOs.Base;

namespace TicketSystem.Application.Contracts.Repositories.Query
{
    public interface IRouteTrainQueryRepository : IMultipleResultQueryRepository<RouteTrain>
    {
        Task<IEnumerable<RouteTrain>> GetAll(GetAllRouteTrainQuery getRouteTrainQuery);
        Task<RouteTrain> GetById(Guid Id);
    }
}

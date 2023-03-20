using TicketSystem.Application.Contracts.Repositories.Query.Base;
using TicketSystem.Application.Queries.Train;
using TicketSystem.Core.Entities;
using Shared.DTOs.Base;
using System.Diagnostics;

namespace TicketSystem.Application.Contracts.Repositories.Query
{
    public interface ITrainQueryRepository : IMultipleResultQueryRepository<Train>
    {
        Task<IEnumerable<Train>> GetAll(GetAllTrainQuery getTrainQuery);
        Task<Train> GetById(Guid Id);
    }
}

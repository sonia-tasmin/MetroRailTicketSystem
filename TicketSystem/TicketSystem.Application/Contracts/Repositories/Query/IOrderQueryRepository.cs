using TicketSystem.Application.Contracts.Repositories.Query.Base;
using TicketSystem.Application.Queries.Order;
using TicketSystem.Core.Entities;
using Shared.DTOs.Base;
using MassTransit.Transports;

namespace TicketSystem.Application.Contracts.Repositories.Query
{
    public interface IOrderQueryRepository : IMultipleResultQueryRepository<Order>
    {
        Task<IEnumerable<Order>> GetAll(GetAllOrderQuery getOrderQuery);
        Task<Order> GetById(Guid Id);
    }
}

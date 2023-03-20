using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TicketSystem.Application.Contracts.Repositories.Query;
using TicketSystem.Application.Queries.Order;
using TicketSystem.Core.Entities;
using TicketSystem.Infrastructure.Configs;
using TicketSystem.Infrastructure.Repository.Query.Base;
using Shared.DTOs.Base;

namespace TicketSystem.Infrastructure.Repository.Query
{
    public class OrderQueryRepository : MultipleResultQueryRepository<Order>, IOrderQueryRepository
    {
        public OrderQueryRepository(IConfiguration configuration, IOptions<TicketSystemSettings> settings) : base(configuration, settings)
        {
        }
        public async Task<IEnumerable<Order>> GetAll(GetAllOrderQuery getOrderQuery)
        {

            var sql = $@"Select config.[Order].Id, config.[Order].userid,config.[User].Name as UserName,config.[Order].seatid,config.Seat.SeatName as SeatName, config.[Order].orderdate, config.[Order].returned
                       From config.[Order]
                       INNER JOIN config.[User] ON config.[Order].UserId = config.[User].Id
					   INNER JOIN config.Seat ON config.[Order].SeatId = config.Seat.Id;";
            return await GetAsync(sql, false);
        }

        public async Task<Order> GetById(Guid Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            var sql = $@"Select * from config.Order where Id = @Id";
            return await SingleAsync(sql, parameters);
        }

    }
}

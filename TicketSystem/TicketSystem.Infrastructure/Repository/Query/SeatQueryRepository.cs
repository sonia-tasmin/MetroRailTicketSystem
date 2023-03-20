using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TicketSystem.Application.Contracts.Repositories.Query;
using TicketSystem.Application.Queries.Seat;
using TicketSystem.Core.Entities;
using TicketSystem.Infrastructure.Configs;
using TicketSystem.Infrastructure.Repository.Query.Base;
using Shared.DTOs.Base;

namespace TicketSystem.Infrastructure.Repository.Query
{
    public class SeatQueryRepository : MultipleResultQueryRepository<Seat>, ISeatQueryRepository
    {
        public SeatQueryRepository(IConfiguration configuration, IOptions<TicketSystemSettings> settings) : base(configuration, settings)
        {
        }
        public async Task<IEnumerable<Seat>> GetAll(GetAllSeatQuery getSeatQuery)
        {

            var sql = $@"Select config.Seat.Id, config.Seat.SeatName, config.Seat.Price, config.Seat.Ordered, config.Seat.RouteTrainId
                       From config.Seat
                       INNER JOIN config.RouteTrain ON config.Seat.RouteTrainId = config.RouteTrain.Id;";
            return await GetAsync(sql, false);
        }

        public async Task<Seat> GetById(Guid Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            var sql = $@"Select * from config.Seat where Id = @Id";
            return await SingleAsync(sql, parameters);
        }

    }
}

using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TicketSystem.Application.Contracts.Repositories.Query;
using TicketSystem.Application.Queries.RouteTrain;
using TicketSystem.Core.Entities;
using TicketSystem.Infrastructure.Configs;
using TicketSystem.Infrastructure.Repository.Query.Base;
using Shared.DTOs.Base;

namespace TicketSystem.Infrastructure.Repository.Query
{
    public class RouteTrainQueryRepository : MultipleResultQueryRepository<RouteTrain>, IRouteTrainQueryRepository
    {
        public RouteTrainQueryRepository(IConfiguration configuration, IOptions<TicketSystemSettings> settings) : base(configuration, settings)
        {
        }
        public async Task<IEnumerable<RouteTrain>> GetAll(GetAllRouteTrainQuery getRouteTrainQuery)
        {

            var sql = $@"Select * from config.RouteTrain;";
            return await GetAsync(sql, false);
        }

        public async Task<RouteTrain> GetById(Guid Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            var sql = $@"Select * from config.RouteTrain where Id = @Id";
            return await SingleAsync(sql, parameters);
        }

    }
}

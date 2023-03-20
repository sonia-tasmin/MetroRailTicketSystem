using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TicketSystem.Application.Contracts.Repositories.Query;
using TicketSystem.Application.Queries.Route;
using TicketSystem.Core.Entities;
using TicketSystem.Infrastructure.Configs;
using TicketSystem.Infrastructure.Repository.Query.Base;
using Shared.DTOs.Base;

namespace TicketSystem.Infrastructure.Repository.Query
{
    public class RouteQueryRepository : MultipleResultQueryRepository<Route>, IRouteQueryRepository
    {
        public RouteQueryRepository(IConfiguration configuration, IOptions<TicketSystemSettings> settings) : base(configuration, settings)
        {
        }
        public async Task<IEnumerable<Route>> GetAll(GetAllRouteQuery getRouteQuery)
        {

            var sql = $@"Select * from config.Route;";
            return await GetAsync(sql, false);
        }

        public async Task<Route> GetById(Guid Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            var sql = $@"Select * from config.Route where Id = @Id";
            return await SingleAsync(sql, parameters);
        }

    }
}

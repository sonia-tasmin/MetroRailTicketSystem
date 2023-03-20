using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TicketSystem.Application.Contracts.Repositories.Query;
using TicketSystem.Application.Queries.Train;
using TicketSystem.Core.Entities;
using TicketSystem.Infrastructure.Configs;
using TicketSystem.Infrastructure.Repository.Query.Base;
using Shared.DTOs.Base;

namespace TicketSystem.Infrastructure.Repository.Query
{
    public class TrainQueryRepository : MultipleResultQueryRepository<Train>, ITrainQueryRepository
    {
        public TrainQueryRepository(IConfiguration configuration, IOptions<TicketSystemSettings> settings) : base(configuration, settings)
        {
        }
        public async Task<IEnumerable<Train>> GetAll(GetAllTrainQuery getTrainQuery)
        {

            var sql = $@"Select * from config.Train;";
            return await GetAsync(sql, false);
        }

        public async Task<Train> GetById(Guid Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            var sql = $@"Select * from config.Train where Id = @Id";
            return await SingleAsync(sql, parameters);
        }

    }
}

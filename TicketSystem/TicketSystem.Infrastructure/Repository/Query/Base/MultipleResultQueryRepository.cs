using TicketSystem.Infrastructure.Configs;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using TicketSystem.Application.Contracts.Repositories.Query.Base;
using TicketSystem.Application.Contracts.Repositories.Query.Base;
using TicketSystem.Infrastructure.Configs;

namespace TicketSystem.Infrastructure.Repository.Query.Base
{
    public class MultipleResultQueryRepository<TEntity> : QueryRepository<TEntity>, IMultipleResultQueryRepository<TEntity> where TEntity : class
    {
        protected MultipleResultQueryRepository(IConfiguration configuration, IOptions<TicketSystemSettings> settings) : base(configuration, settings)
        {
        }

        //Implementation of IMultipleResultQuery interface
        public async Task<(long, IEnumerable<TEntity>)> GetMultipleResultAsync(string sql, DynamicParameters parameters, bool isProcedure = false)
        {
            using var connection = CreateConnection();
            var grid = await connection.QueryMultipleAsync(sql, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
            var result = await grid.ReadAsync<TEntity>();
            var count = (await grid.ReadAsync<long>()).FirstOrDefault();
            return (count, result);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

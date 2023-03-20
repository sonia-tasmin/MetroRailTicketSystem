using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TicketSystem.Application.Contracts.Repositories.Query;
using TicketSystem.Application.Queries.User;
using TicketSystem.Core.Entities;
using TicketSystem.Infrastructure.Configs;
using TicketSystem.Infrastructure.Repository.Query.Base;
using Shared.DTOs.Base;

namespace TicketSystem.Infrastructure.Repository.Query
{
    public class UserQueryRepository : MultipleResultQueryRepository<User>, IUserQueryRepository
    {
        public UserQueryRepository(IConfiguration configuration, IOptions<TicketSystemSettings> settings) : base(configuration, settings)
        {
        }
        public async Task<IEnumerable<User>> GetAll(GetAllUserQuery getUserQuery)
        {

            var sql = $@"SELECT * FROM [config].[User];";
            return await GetAsync(sql, false);
        }

        public async Task<User> GetById(Guid Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            var sql = $@"Select * from config.User where Id = @Id";
            return await SingleAsync(sql, parameters);
        }

        public async Task<User> IsUserValid(string email, string password)
        {
            var sql = $@"SELECT * FROM [config].[User]  where Email='"+email+"' and password='"+ password + "'";
            return await SingleAsync(sql, false);
        }
    }
}

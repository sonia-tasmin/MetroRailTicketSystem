using TicketSystem.Infrastructure.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace TicketSystem.Infrastructure.Persistence
{
    public class DbConnector
    {
        private readonly IConfiguration _configuration;
        private readonly TicketSystemSettings _settings;
        protected DbConnector(IConfiguration configuration, IOptions<TicketSystemSettings> settings)
        {
            _configuration = configuration;
            _settings = settings.Value;
        }

        public IDbConnection CreateConnection()
        {
            string _connectionString = _settings.ConnectionStrings.TicketSystemDbConnection;
            return new SqlConnection(_connectionString);
        }
    }
}

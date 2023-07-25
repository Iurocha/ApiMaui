using cliente.Core.Application.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace cliente.Infrastructure.EntityFrameworkCore.Context
{
    public class ClienteContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public ClienteContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

    }
}

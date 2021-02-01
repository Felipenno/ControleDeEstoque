using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CDE.Infra
{
    public class DataProviders
    {
        private readonly IConfiguration _config;

        public DataProviders(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IDbConnection CDE_DbConnection()
        {
            return new SqlConnection(_config.GetConnectionString("SqlServerConnection"));
        }
    }
}

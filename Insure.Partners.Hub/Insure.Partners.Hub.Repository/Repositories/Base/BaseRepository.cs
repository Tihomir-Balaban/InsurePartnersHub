using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Insure.Partners.Hub.Repository.Repositories.Base
{
    public class BaseRepository
    {
        private readonly string connectionString;

        public BaseRepository()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        protected IDbConnection CreateConnection()
            => new SqlConnection(connectionString);
    }
}

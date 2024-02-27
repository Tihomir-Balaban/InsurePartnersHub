using System.Data;
using System.Data.SqlClient;

namespace Insure.Partners.Hub.Repository.Repositories.Base
{
    public class BaseRepository
    {
        private readonly string connectionString;

        public BaseRepository(string connectionString)
            => this.connectionString = connectionString;

        protected IDbConnection CreateConnection()
            => new SqlConnection(connectionString);
    }
}

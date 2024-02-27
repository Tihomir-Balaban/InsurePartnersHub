using Dapper;
using Insure.Partners.Hub.Models.Dto;
using Insure.Partners.Hub.Repository.Interfaces;
using Insure.Partners.Hub.Repository.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Repository
{
    public class PolicyRepository : BaseRepository, IPolicyRepository
    {
        public PolicyRepository(string connectionString) : base(connectionString) { }

        public async Task<IEnumerable<Policy>> GetByPartnerIdAsync(int partnerId)
        {
            var query = "SELECT * FROM Policies WHERE PartnerId = @PartnerId";

            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<Policy>(query, new { PartnerId = partnerId });
            }
        }

        // Implement other CRUD operations similarly
    }

}

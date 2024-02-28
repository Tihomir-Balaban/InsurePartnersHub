using Dapper;
using Insure.Partners.Hub.Models.Dto;
using Insure.Partners.Hub.Repository.Interfaces;
using Insure.Partners.Hub.Repository.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Repository.Repositories
{
    public class PartnerRepository : BaseRepository, IPartnerRepository
    {
        public PartnerRepository(string connectionString) : base(connectionString) { }

        public async Task<IEnumerable<Partner>> GetAllAsync()
        {
            var query = "SELECT * FROM Partners";

            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<Partner>(query);
            }
        }
    }
}

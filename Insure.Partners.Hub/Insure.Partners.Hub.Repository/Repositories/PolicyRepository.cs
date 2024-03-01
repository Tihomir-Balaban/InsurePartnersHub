using Dapper;
using Insure.Partners.Hub.Models.Dto;
using Insure.Partners.Hub.Repository.Interfaces;
using Insure.Partners.Hub.Repository.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Repository.Repositories
{
    public class PolicyRepository : BaseRepository, IPolicyRepository
    {
        public PolicyRepository() : base() { }

        public async Task<IEnumerable<Policy>> GetByPartnerIdAsync(int partnerId)
        {
            var query = "SELECT * FROM [Policy] WHERE [PartnerId] = @PartnerId;";

            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<Policy>(query, new { PartnerId = partnerId });
            }
        }

        public async Task<IEnumerable<Policy>> GetByPartnersIdAsync(int[] partnerIds)
        {
            var query = "SELECT * FROM [Policy] WHERE [PartnerId] IN @PartnerIds;";

            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<Policy>(query, new { PartnerIds = partnerIds });
            }
        }

        public async Task<Policy> AddPolicyAsync(Policy policy)
        {

            var query = @"INSERT INTO [Policy] (ShelfNumber, PolicyAmount, PartnerId)
                          VALUES (@ShelfNumber, @PolicyAmount, @PartnerId);";

            var queryRetrieveEnteredRecord = @"SELECT TOP 1 * FROM [Policy] ORDER BY ID DESC";

            var data = new
            {
                ShelfNumber = policy.ShelfNumber,
                PolicyAmount = policy.PolicyAmount,
                PartnerId = policy.PartnerId
            };


            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(query, data);

                return await connection.QuerySingleAsync<Policy>(queryRetrieveEnteredRecord);
            }
        }
    }
}

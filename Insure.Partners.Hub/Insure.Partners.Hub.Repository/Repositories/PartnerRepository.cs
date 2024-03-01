using Dapper;
using Insure.Partners.Hub.Models.Dto;
using Insure.Partners.Hub.Repository.Interfaces;
using Insure.Partners.Hub.Repository.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Repository.Repositories
{
    public class PartnerRepository : BaseRepository, IPartnerRepository
    {
        public PartnerRepository() : base() { }

        public async Task<IEnumerable<Partner>> GetAllAsync()
        {
            var query = @"SELECT * FROM [Partners] 
                          ORDER BY [CreatedAtUtc] DESC";

            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<Partner>(query);
            }
        }

        public async Task<IEnumerable<Partner>> GetAllExceptByIdAsync(int id)
        {
            var query = @"SELECT * FROM [Partners] 
                        WHERE [Id] != @Id
                        ORDER BY [CreatedAtUtc] DESC;";

            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<Partner>(query, new { Id = id });
            }
        }

        public async Task<Partner> AddPartnerAsync(Partner partner)
        {
            var query = @"INSERT INTO [Partners] (FirstName, LastName, Address, PartnerNumber, CroatianPIN, PartnerTypeId, CreatedAtUtc, CreateByUser, IsForeign, ExternalCode, Gender)
                          VALUES (@FirstName, @LastName, @Address, @PartnerNumber, @CroatianPIN, @PartnerTypeId, @CreatedAtUtc, @CreateByUser, @IsForeign, @ExternalCode, @Gender)";

            var queryRetrieveEnteredRecord = @"SELECT TOP 1 * FROM [Partners] ORDER BY ID DESC";

            var data = new
            {
                FirstName = partner.FirstName,
                LastName = partner.LastName,
                Address = partner.Address,
                PartnerNumber = partner.PartnerNumber,
                CroatianPIN = partner.CroatianPIN,
                PartnerTypeId = partner.PartnerTypeId,
                CreatedAtUtc = DateTime.Now,
                CreateByUser = partner.CreateByUser,
                IsForeign = partner.IsForeign,
                ExternalCode = partner.ExternalCode,
                Gender = partner.Gender
            };

            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(query, data);

                return await connection.QuerySingleAsync<Partner>(queryRetrieveEnteredRecord);
            }
        }
    }
}

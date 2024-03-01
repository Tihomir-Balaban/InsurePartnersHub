using Insure.Partners.Hub.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Repository.Interfaces
{
    public interface IPartnerRepository
    {
        Task<IEnumerable<Partner>> GetAllAsync();
        Task<IEnumerable<Partner>> GetAllExceptByIdAsync(int id);
        Task<Partner> GetByIdAsync(int id);
        Task<Partner> AddPartnerAsync(Partner partner);
    }
}

using Insure.Partners.Hub.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Service.Interfaces
{
    public interface IPartnerService
    {
        Task<IEnumerable<Partner>> GetAllAsync();
        Task<Partner> AddPartnerAsync(Partner partner);
    }
}

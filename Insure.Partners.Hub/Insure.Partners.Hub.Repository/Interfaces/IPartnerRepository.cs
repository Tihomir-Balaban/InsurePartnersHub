using Insure.Partners.Hub.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Repository.Interfaces
{
    public interface IPartnerRepository
    {
        Task<IEnumerable<Partner>> GetAllAsync();
    }
}

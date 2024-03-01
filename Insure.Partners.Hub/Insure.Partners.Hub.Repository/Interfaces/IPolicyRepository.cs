using Insure.Partners.Hub.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Repository.Interfaces
{
    public interface IPolicyRepository
    {
        Task<IEnumerable<Policy>> GetByPartnerIdAsync(int partnerId);
        Task<IEnumerable<Policy>> GetByPartnersIdAsync(int[] partnerIds);
        Task<Policy> AddPolicyAsync(Policy policy);
    }
}

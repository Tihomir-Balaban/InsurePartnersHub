using Insure.Partners.Hub.Models.Dto;
using Insure.Partners.Hub.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Service.Interfaces
{
    public interface IPolicyService
    {
        Task<IEnumerable<PolicyViewModel>> GetByPartnerIdAsync(int partnerId);
        Task<Policy> AddPolicyAsync(Policy policy);
    }
}

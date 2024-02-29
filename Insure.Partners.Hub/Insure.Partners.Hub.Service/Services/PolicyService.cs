using Insure.Partners.Hub.Models.Dto;
using Insure.Partners.Hub.Repository.Interfaces;
using Insure.Partners.Hub.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Service.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository policyRepository;

        public PolicyService(IPolicyRepository policyRepository)
        {
            this.policyRepository = policyRepository;
        }

        public async Task<IEnumerable<Policy>> GetByPartnerIdAsync(int partnerId)
            => await policyRepository.GetByPartnerIdAsync(partnerId);

        public async Task<Policy> AddPolicyAsync(Policy policy)
            => await policyRepository.AddPolicyAsync(policy);
    }
}

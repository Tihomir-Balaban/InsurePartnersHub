using Insure.Partners.Hub.Models.Dto;
using Insure.Partners.Hub.Models.ViewModels;
using Insure.Partners.Hub.Repository.Interfaces;
using Insure.Partners.Hub.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Service.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository policyRepository;
        private readonly IPartnerRepository partnerRepository;

        public PolicyService(IPolicyRepository policyRepository, IPartnerRepository partnerRepository)
        {
            this.policyRepository = policyRepository;
            this.partnerRepository = partnerRepository;
        }

        public async Task<IEnumerable<PolicyViewModel>> GetByPartnerIdAsync(int partnerId)
        {
            var partnerPolicies = await policyRepository.GetByPartnerIdAsync(partnerId);
            var partner = await partnerRepository.GetByIdAsync(partnerId);

            var results = ConvertToViewModel(partnerPolicies, partner);

            return results;
        }

        public async Task<Policy> AddPolicyAsync(Policy policy)
            => await policyRepository.AddPolicyAsync(policy);
        
        #region Private Methods
        private IEnumerable<PolicyViewModel> ConvertToViewModel(IEnumerable<Policy> policies, Partner partner)
        {
            var results = new List<PolicyViewModel>();

            foreach (var policy in policies)
            {
                var result = new PolicyViewModel()
                {
                    Id = policy.Id,
                    PartnerFullName = string.Concat(partner.FirstName, ' ', partner.LastName),
                    ShelfNumber = policy.ShelfNumber,
                    PolicyAmount = policy.PolicyAmount,
                    PartnerId = policy.PartnerId
                };

                results.Add(result);
            }

            return results;
        }
        #endregion
    }
}

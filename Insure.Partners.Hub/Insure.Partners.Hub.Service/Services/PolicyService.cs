using Insure.Partners.Hub.Repository.Interfaces;
using Insure.Partners.Hub.Service.Interfaces;

namespace Insure.Partners.Hub.Service.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository policyRepository;

        public PolicyService(IPolicyRepository policyRepository)
        {
            this.policyRepository = policyRepository;
        }
    }
}

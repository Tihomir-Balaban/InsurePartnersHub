using Insure.Partners.Hub.Repository.Interfaces;
using Insure.Partners.Hub.Service.Interfaces;

namespace Insure.Partners.Hub.Service.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository partnerRepository;

        public PartnerService(IPartnerRepository partnerRepository)
        {
            this.partnerRepository = partnerRepository;
        }
    }
}

using Insure.Partners.Hub.Models.Dto;
using Insure.Partners.Hub.Repository.Interfaces;
using Insure.Partners.Hub.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Service.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository partnerRepository;

        public PartnerService(IPartnerRepository partnerRepository)
        {
            this.partnerRepository = partnerRepository;
        }

        public async Task<IEnumerable<Partner>> GetAllAsync()
            => await partnerRepository.GetAllAsync();


        public async Task<Partner> AddPartnerAsync(Partner partner)
            => await partnerRepository.AddPartnerAsync(partner);

    }
}

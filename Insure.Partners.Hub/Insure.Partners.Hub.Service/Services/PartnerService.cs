using Insure.Partners.Hub.Models.Dto;
using Insure.Partners.Hub.Models.ViewModels;
using Insure.Partners.Hub.Repository.Interfaces;
using Insure.Partners.Hub.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Service.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository partnerRepository;
        private readonly IPolicyRepository policyRepository;

        public PartnerService(IPartnerRepository partnerRepository, IPolicyRepository policyRepository)
        {
            this.partnerRepository = partnerRepository;
            this.policyRepository = policyRepository;
        }

        public async Task<IEnumerable<PartnerViewModel>> GetAllAsync()
        {
            var partners =  await partnerRepository.GetAllAsync();

            var results = await ConverAndCheckForMarks(partners);

            return results;
        }

        public async Task<Partner> AddPartnerAsync(Partner partner)
            => await partnerRepository.AddPartnerAsync(partner);

        #region Private Methods
        private async Task<IEnumerable<PartnerViewModel>> ConverAndCheckForMarks(IEnumerable<Partner> partners)
        {
            var listPartnerViewModels =  ConverToViewModel(partners);

            var results = await CheckForMarks(listPartnerViewModels);

            return results;
        }

        private IEnumerable<PartnerViewModel> ConverToViewModel(IEnumerable<Partner> partners)
        {
            var results = new List<PartnerViewModel>();

            foreach (var partner in partners)
            {
                var result = new PartnerViewModel()
                {
                    Id = partner.Id,
                    FirstName = partner.FirstName,
                    LastName = partner.LastName,
                    Address = partner.Address,
                    PartnerNumber = partner.PartnerNumber,
                    CroatianPIN = partner.CroatianPIN,
                    PartnerTypeId = partner.PartnerTypeId,
                    CreatedAtUtc = partner.CreatedAtUtc,
                    CreateByUser = partner.CreateByUser,
                    IsForeign = partner.IsForeign,
                    ExternalCode = partner.ExternalCode,
                    Gender = partner.Gender,
                    IsMarked = false,
                    IsNew = false,
                };

                results.Add(result);
            }

            return results;
        }

        private async Task<IEnumerable<PartnerViewModel>> CheckForMarks(IEnumerable<PartnerViewModel> listPartnerViewModels)
        {
            var ids = listPartnerViewModels
                .Select(s => s.Id)
                .ToArray();

            var policies = await policyRepository.GetByPartnersIdAsync(ids);

            foreach (var id in ids)
            {
                var policyAmount = policies
                    .Where(p => p.PartnerId == id)
                    .Select(s => s.PolicyAmount);

                var policyAmountSum = policyAmount.Sum();

                if (policyAmount.Count() >= 5 || policyAmountSum >= 5000.00M)
                    listPartnerViewModels.Where(l => l.Id == id).Single().IsMarked = true;
            }

            return listPartnerViewModels;
        }
        #endregion
    }
}

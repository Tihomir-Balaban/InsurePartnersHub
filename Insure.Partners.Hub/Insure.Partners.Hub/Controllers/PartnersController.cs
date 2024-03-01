using Insure.Partners.Hub.Models.Dto;
using Insure.Partners.Hub.Models.ViewModels;
using Insure.Partners.Hub.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Insure.Partners.Hub.Controllers
{
    public class PartnersController : Controller
    {
        private readonly IPartnerService partnerService;

        public PartnersController(IPartnerService partnerService)
        {
            this.partnerService = partnerService;
        }

        [HttpGet]
        public async Task<ActionResult> Index(PartnerViewModel newlyAddedPartner)
        {
            var partnersViewModel = new List<PartnerViewModel>();

            if (!newlyAddedPartner.IsNew)
            {
                 partnersViewModel.AddRange(await partnerService.GetAllAsync());
            }
            else
            {
                var allOldPartnerViewModels = await partnerService.GetAllExceptByIdAsync(newlyAddedPartner.Id);

                partnersViewModel.Add(newlyAddedPartner);

                partnersViewModel.AddRange(allOldPartnerViewModels);
            }

            return View(partnersViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Partner partner)
        {
            if (!ModelState.IsValid)
            {
                return View(partner);
            }
            var result = await partnerService.AddPartnerAsync(partner);

            ViewBag.PartnerId = result.Id;

            return RedirectToAction("Index", "Partners", result);
        }
    }
}
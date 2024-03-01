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

        public async Task<ActionResult> Index()
        {
            var partnersViewModel = await partnerService.GetAllAsync();

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

            return RedirectToAction("Create", "Policies");
        }
    }
}
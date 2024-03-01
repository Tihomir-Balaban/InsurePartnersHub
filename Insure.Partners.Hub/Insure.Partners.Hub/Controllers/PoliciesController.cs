using Insure.Partners.Hub.Models.Dto;
using Insure.Partners.Hub.Service.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Insure.Partners.Hub.Controllers
{
    public class PoliciesController : Controller
    {
        private readonly IPolicyService policyService;

        public PoliciesController(IPolicyService policyRepository)
        {
            policyService = policyRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int partnerId)
        {
            var policies = await policyService.GetByPartnerIdAsync(partnerId);

            return View(policies);
        }

        [HttpGet]
        public async Task<ActionResult> Create(int partnerId)
        {
            ViewBag.PartnerId = partnerId;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Policy policy)
        {
            if (!ModelState.IsValid)
            {
                return View(policy);
            }

            var result = await policyService.AddPolicyAsync(policy);

            return RedirectToAction("Index", "Policies", new { partnerId = result.PartnerId });
        }
    }
}
using Insure.Partners.Hub.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Insure.Partners.Hub.Models.Dto;

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
            var result = await policyService.AddPolicyAsync(policy);

            return RedirectToAction("Index", "Policies", new { partnerId = policy.PartnerId });
        }
    }
}
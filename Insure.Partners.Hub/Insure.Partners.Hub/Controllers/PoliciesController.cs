using Insure.Partners.Hub.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

        public async Task<ActionResult> Index(int partnerId)
        {
            var policies = await policyService.GetByPartnerIdAsync(partnerId);
            return View(policies);
        }
    }
}
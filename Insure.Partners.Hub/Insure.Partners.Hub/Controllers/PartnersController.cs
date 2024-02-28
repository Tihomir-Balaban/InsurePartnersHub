using Insure.Partners.Hub.Service.Interfaces;
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
            var partners = await partnerService.GetAllAsync();

            return View(partners);
        }
    }
}
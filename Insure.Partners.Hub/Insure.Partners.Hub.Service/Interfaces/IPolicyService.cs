using Insure.Partners.Hub.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insure.Partners.Hub.Service.Interfaces
{
    public interface IPolicyService
    {
        Task<IEnumerable<Policy>> GetByPartnerIdAsync(int partnerId);
    }
}

using System.Collections.Generic;
using System.Web.Mvc;

namespace Insure.Partners.Hub.Models.ViewModels
{
    public class DropDownModel
    {
        public string SelectedItemId { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}

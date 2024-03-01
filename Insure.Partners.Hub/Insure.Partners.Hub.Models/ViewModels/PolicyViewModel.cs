namespace Insure.Partners.Hub.Models.ViewModels
{
    public class PolicyViewModel
    {
        public int Id { get; set; }
        public string ShelfNumber { get; set; }
        public decimal PolicyAmount { get; set; }
        public int PartnerId { get; set; }
        public string PartnerFullName { get; set; }
    }
}

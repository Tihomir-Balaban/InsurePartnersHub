namespace Insure.Partners.Hub.Models.Dto
{
    public class Policy
    {
        public int Id { get; set; }
        public string ShelfNumber { get; set; }
        public decimal PolicyAmount { get; set; }
        public int PartnerId { get; set; }
        // Navigation property
        public Partner Partner { get; set; }
    }
}

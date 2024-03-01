using Insure.Partners.Hub.Models.Dto;
using System;
using System.Collections.Generic;

namespace Insure.Partners.Hub.Models.ViewModels
{
    public class PartnerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public long PartnerNumber { get; set; }
        public long CroatianPIN { get; set; }
        public int PartnerTypeId { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public string CreateByUser { get; set; }
        public bool IsForeign { get; set; }
        public string ExternalCode { get; set; }
        public char Gender { get; set; }
        public bool IsMarked { get; set; }
        public bool IsNew { get; set; }
        public List<Policy> Policies { get; set; }
    }
}

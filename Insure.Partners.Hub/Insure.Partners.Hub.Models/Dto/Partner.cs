using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Insure.Partners.Hub.Models.Dto
{
    public class Partner
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "The FirstName must be at least 2 characters long and not exceed 255 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The FirstName must be alphanumeric.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "The LastName must be at least 2 characters long and not exceed 255 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The LastName must be alphanumeric.")]
        public string LastName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9.\s]*$", ErrorMessage = "The Address must be alphanumeric.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The PartnerNumber field is required.")]
        [RegularExpression(@"^\d{19}$", ErrorMessage = "The PartnerNumber must be exactly 19 digits.")]
        public long PartnerNumber { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "The OIB must be exactly 11 digits.")]
        public long CroatianPIN { get; set; }

        [Required(ErrorMessage = "The Partner Type field is required.")]
        public int PartnerTypeId { get; set; }
        public DateTime CreatedAtUtc { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [StringLength(255, ErrorMessage = "The Email Address must not exceed 255 characters.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string CreateByUser { get; set; }

        [Required(ErrorMessage = "IsForeign is required.")]
        public bool IsForeign { get; set; }

        [Required(ErrorMessage = "ExternalCode is required.")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "The ExternalCode must be at least 10 characters long and not exceed 20 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The ExternalCode must be alphanumeric.")]
        public string ExternalCode { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public char Gender { get; set; }
        public List<Policy> Policies { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Insure.Partners.Hub.Models.Dto
{
    public class Policy
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ShelfNumber is required.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "The ShelfNumber must be at least 10 characters long and not exceed 15 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The ShelfNumber must be alphanumeric.")]
        public string ShelfNumber { get; set; }

        [Required(ErrorMessage = "The Policy amount is required.")]
        public decimal PolicyAmount { get; set; }
        public int PartnerId { get; set; }
    }
}

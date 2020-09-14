using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationUsers.Models
{
    public class PhonesModel
    {
        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }

        [Required]
        [Display(Name = "Area_Code")]
        public int Area_Code { get; set; }

        [Required]
        [MaxLength(3)]
        [StringLength(3, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Country_Code")]
        public string Country_Code { get; set; }
    }
}
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public class OrganisationViewModel
    {
        [Display(Name = "Organisation Id: ")]
        public string OrganisationId { get; set; }

        [Display(Name = "Name: ")]
        public string OrganisationName { get; set; }

        [Display(Name = "Location: ")]
        public string OrganisationAddress { get; set; }
        public IFormFile Pic { get; set; }
    }
}

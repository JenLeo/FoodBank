using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public class OrganisationViewModel
    {
        public string OrganisationID { get; set; }
        public string OrganisationName { get; set; }
        public string OrganisationAddress { get; set; }
        public IFormFile Pic { get; set; }
    }
}

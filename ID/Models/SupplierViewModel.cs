using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public class SupplierViewModel
    {
        [Display(Name = "Partner's ID: ")]
        public string SupplierId { get; set; }

        [Display(Name = "Name: ")]
        public string SupplierName { get; set; }

        [Display(Name = "Location: ")]
        public string SupplierAddress { get; set; }
        public IFormFile Pic { get; set; }
    }
}

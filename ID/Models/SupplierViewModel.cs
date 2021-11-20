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
        [Display(Name = "Supplier ID: ")]
        public string SupplierId { get; set; }

        [Display(Name = "Supplier Name: ")]
        public string SupplierName { get; set; }

        [Display(Name = "Supplier Location: ")]
        public string SupplierAddress { get; set; }
        public IFormFile Pic { get; set; }
    }
}

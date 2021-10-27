using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public class PackageViewModel
    {
        [Display(Name = "Package Id: ")] 
        public string PackageId { get; set; }

        [Display(Name = "Package Name: ")]
        public string PackageNameId { get; set; }

        [Display(Name = "Description: ")]
        public string PackageDetail { get; set; }

        [Display(Name = "Type: ")]
        public string PackageType { get; set; }

        [Display(Name = "Package Type: ")]
        [Required(ErrorMessage = "Please choose a package type")]
        public static String[] PackageTypes
        {
            get
            {
                return new String[] { "Perishable", "Nonperishable", "Hygiene", "Household" };
            }
        }

        [Display(Name = "Price: ")]
        public decimal PackagePrice { get; set; }
        
        [Display(Name = "Supplier ")]
        public string SupplierId { get; set; }

        public List<SelectListItem> Suppliers { get; set; }

        public virtual Supplier Supplier { get; set; }

        [Display(Name = " ")]
        public IFormFile Pic { get; set; }

    }
}

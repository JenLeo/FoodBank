using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public class PackageViewModel
    {
        [Display(Name = "Package ID: ")] 
        public string PackageID { get; set; }

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
        public int PackagePrice { get; set; }

        [Display(Name = " ")]
        public IFormFile Pic { get; set; }

    }
}

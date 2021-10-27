using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Partner's ID: ")]
        public string SupplierId{ get; set; }

        [Display(Name = "Name: ")]
        public string SupplierName { get; set; }

        [Display(Name = "Location: ")]
        public string SupplierAddress { get; set; }

        public string Pic { get; set; }

        public List<Package> Packages { get; set; }
    }
}

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
        [Display(Name = "Supplier ID: ")]
        public string SupplierId{ get; set; }

        [Display(Name = "Supplier Name: ")]
        public string SupplierName { get; set; }

        [Display(Name = "Supplier Location: ")]
        public string SupplierAddress { get; set; }

        public string Pic { get; set; }

    
        public ICollection<Package> Packages { get; set; }

    }
}

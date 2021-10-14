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
        public string SupplierID { get; set; }

        [Display(Name = "Name: ")]
        public String SupplierName { get; set; }

        [Display(Name = "Location: ")]
        public String SupplierAddress { get; set; }

        public string Pic { get; set; }
    }
}

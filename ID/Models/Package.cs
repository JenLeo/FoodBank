using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace ID.Models
{
    public class Package
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Package ID: ")]
        public string PackageId { get; set; }

        [Display(Name = "Package: ")]
        public string PackageNameId { get; set; }

        [Display(Name = "Description: ")]
        public string PackageDetail { get; set; }

        [Display(Name = "Type: ")]
        public string PackageType { get; set; }


        [Display(Name = "Price (€): ")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PackagePrice { get; set; }

       
        public string Pic { get; set; }

        [ForeignKey("Supplier :")]
        [Display(Name = "Supplier: ")]
        public string SupplierId { get; set; }

        [Display(Name = "Supplier: ")]
        public Supplier Supplier { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
    public enum PackageTypes
    {
        Perishable, 
        Nonperishable, 
        Hygiene, 
        Household
    }
}
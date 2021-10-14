using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace ID.Models
{

    public class Packages
    {
        //private readonly AppDbContext _ap = new AppDbContext();
        //public List<Packages> packages
        //{
        //    get; set;
        //}

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Package ID: ")]
        public string PackageID { get; set; }

        //[Display(Name = "Packages: ")]
        //[Required(ErrorMessage = "Please choose a package type")]
        //public static String[] PackageTypes
        //{
        //    get
        //    {
        //        return new String[] { "Perishable", "Nonperishable", "Hygiene", "Household" };
        //    }
        //}

        [Display(Name = "Type: ")]
        public string PackageType { get; set; }

        [Display(Name = "Package: ")]
        public String PackageNameId { get; set; }

        [Display(Name = "Description: ")]
        public String PackageDetail { get; set; }


        [Display(Name = "Price (€): ")]
        public int PackagePrice { get; set; }
    
        public string Pic { get; set; }

        public static implicit operator Packages(List<Packages> v)
        {
            throw new NotImplementedException();
        }
        //public ICollection<Cart> Cart { get; set; }
    }
    public enum PackageTypes
    {
        Perishable, 
        Nonperishable, 
        Hygiene, 
        Household
    }
}
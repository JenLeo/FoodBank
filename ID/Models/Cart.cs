using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public class Cart
    {
        [Key]
        public int TypeId { get; set; }
        public string CartId { get; set; }
        public string PackageID { get; set; }
        public int Count { get; set; }
        public System.DateTime AddedOn { get; set; }

        public Packages Packages = new();
      

        //public virtual Packages Packages { get; set; }
        //public Cart()
        //{

        //    this.PackageID = Packages.PackageID;


        //}


        //public List<Packages> findAll()
        //{
        //    return this.Packages;

        //}

        //public Packages find(string id)
        //{
        //    return this.Packages.Single(p => p.PackageID.Equals(id));
        //}
    }
}

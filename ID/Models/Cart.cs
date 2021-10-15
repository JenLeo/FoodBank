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


        public Packages Packages { get; set; }
        public Cart()
        {
            Packages = new Packages();



        }
    }
}

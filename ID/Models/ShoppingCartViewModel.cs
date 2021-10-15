using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public class ShoppingCartViewModel 
    {


        //public List<Cart> CartItems { get; set;  }
        public ShoppingCart ShoppingCart { get; set; }
        //public ShoppingCartViewModel()
        //{
        //    this.CartItems = new List<Cart>();
        //    this.packages = new List<Packages>();
        //}


        //}
        //public List<Cart> findAll()
        //{
        //    return this.CartItems;

        //}

        //public Cart find(string id)
        //{
        //    return this.CartItems.Single(p => p.PackageID.Equals(id));
        //}
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CartTotal { get; set; }

       
    }
}

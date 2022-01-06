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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CartId { get; set; }
        public int Count { get; set; }
        public string ShoppingCartId { get; set; }
        public string PackageId { get; set; }
        public Package Package { get; set; }

        public ICollection<Order> Order { get; set; }

    }
}

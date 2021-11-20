//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ID.Models
//{
//    public enum Status
//    {
//        Complete, Cancelled
//    }
//    public class CartOrder
//    {
//        //public CartOrder()
//        //    {
//        //    Order = new Order();
//        //    Cart = new Cart();
//        //    }
//        public string CartOrderId { get; set; }
//        public string OrderId { get; set; }

//        [DisplayFormat(NullDisplayText = "Pending")]
//        public Status? Status { get; set; }
//        public string CartId { get; set; }

//        public Order Order { get; set; }
//        public Cart Cart { get; set; }
//    }
//}

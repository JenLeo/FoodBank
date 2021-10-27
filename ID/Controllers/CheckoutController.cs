﻿using ID.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ID.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        private readonly ShoppingCart _shoppingCart;

        public CheckoutController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
{
    _orderRepository = orderRepository;
    _shoppingCart = shoppingCart;
}


public IActionResult CheckOut()
{
    return View();
}

//[Authorize]
[HttpPost]
//[Authorize(Policy = "MinimumOrderAge")]
public IActionResult CheckOut(Order order)
{
    var items = _shoppingCart.GetShoppingCartItems();

    if (_shoppingCart.ShoppingCartItems.Count == 0)
    {
        ModelState.AddModelError("", "Your cart is empty");
    }

    if (ModelState.IsValid)
    {
        _orderRepository.CreateOrder(order);
        _shoppingCart.ClearCart();
        return RedirectToAction("CheckoutComplete");
    }
    return View(order);



}

public IActionResult CheckoutComplete()
{
    if (!string.IsNullOrEmpty(HttpContext.User.Identity.Name))
    {
        ViewBag.CheckoutCompleteMessage = HttpContext.User.Identity.Name +
                                          ", thanks for your order!";
    }
    else
    {
        ViewBag.CheckoutCompleteMessage = "Thanks for your order!";
    }


    return View();

}
    }
}
    //    //readonly AppDbContext apDB = new AppDbContext();
    //    //const string PromoCode = "FREE";

    //    // GET: /Checkout/AddressAndPayment
    //    public ActionResult AddressAndPayment()
    //    {
    //        return View();
    //    }

        // POST: /Checkout/AddressAndPayment
        //[HttpPost]
        //public ActionResult AddressAndPayment(IFormCollection values)
        //{
        //    var order = new Order();
        //    TryUpdateModelAsync(order);

        //    try
        //    {
        //        if (string.Equals(values["PromoCode"], PromoCode,
        //            StringComparison.OrdinalIgnoreCase)/* == false*/)
        //        {
        //            return View(order);
        //        }
        //        else
        //        {
        //            order.Username = User.Identity.Name;
        //            order.OrderDate = DateTime.Now;

        //            //Save Order
        //            apDB.Orders.Add(order);
        //            apDB.SaveChanges();
        //            //Process the order
        //            var cart = ShoppingCart.GetCart(this.HttpContext);
        //            cart.CreateOrder(order);
        //            return RedirectToAction("Complete", new { id = order.OrderId });
        //        }
        //    }
        //    catch
        //    {
        //        //Invalid - redisplay with errors
        //        return View(order);
        //    }
        //}
        // GET: /Checkout/Complete
//        public ActionResult Complete(int id)
//        {
//            // Validate customer owns this order
//            bool isValid = apDB.Orders.Any(
//                o => o.OrderId == id &&
//                o.Username == User.Identity.Name);

//            if (isValid)
//            {
//                return View(id);
//            }
//            else
//            {
//                return View("Error");
//            }
//        }

//    }


//}

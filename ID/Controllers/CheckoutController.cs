using ID.Models;
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
   
using ID.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ID.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        private readonly ShoppingCart _shoppingCart;
        private readonly AppDbContext _context;
   

        public CheckoutController(IOrderRepository orderRepository, 
            ShoppingCart shoppingCart, AppDbContext context
          )
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _context = context;
        }
     

        public IActionResult CheckOut()
        {
            PopulateOrganisationsDropDownList();
            return View();
        }


        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            _ = _shoppingCart.GetShoppingCartItems();

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
        private void PopulateOrganisationsDropDownList(object selectedOrganisation = null)
        {
            var organisationsQuery = from d in _context.Organisations
                                     orderby d.OrganisationName
                                     select d;
            ViewBag.OrganisationId = new SelectList(organisationsQuery.AsNoTracking(), "OrganisationId", "OrganisationName", selectedOrganisation);
        }
        public IActionResult CheckoutComplete()
        {
            if (!string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                ViewBag.CheckoutCompleteMessage = HttpContext.User.Identity.Name +
                                                  ", thanks you for your order!";
            }
            else
            {
                ViewBag.CheckoutCompleteMessage = "Thank you for your order!";
            }


            return View();

        }
    }
}
   
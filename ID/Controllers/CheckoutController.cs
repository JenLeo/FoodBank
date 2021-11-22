using ID.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iD.Models;
using System.Collections.Generic;

namespace ID.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        private readonly ShoppingCart _shoppingCart;
        private readonly AppDbContext _context;
        private readonly IDeliverContext _deliverContext;

        public CheckoutController(IOrderRepository orderRepository, 
            ShoppingCart shoppingCart, AppDbContext context,
            IDeliverContext deliverContext)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _context = context;
            _deliverContext = deliverContext;
        }
        private List<Delivery> GetDeliveries()
        {
            return new List<Delivery>()
    {
        new Delivery()
        {
            Id = 1,
            Name="(€0.00)"
        },
        new Delivery() {
            Id = 2,
            Name="Donate (€1.00)"
        },
        new Delivery() {
            Id = 3,
            Name="Donate (€5.00)"
        },
         new Delivery() {
            Id = 4,
            Name="Donate (€10.00)"
        },
           new Delivery() {
            Id = 5,
            Name="Donate (€15.00)"
        },
             new Delivery() {
            Id = 6,
            Name="Donate (€25.00)"
        },
               new Delivery() {
            Id = 7,
            Name="Donate (€50.00)"
        },
    };
        }

        public IActionResult CheckOut()
        {
            PopulateOrganisationsDropDownList();
            return View();
        }


        [HttpPost]
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
   
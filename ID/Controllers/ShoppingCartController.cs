﻿using System;
using System.Linq;
using ID;
using ID.Controllers;
using ID.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ID.Controllers
{
    public class ShoppingCartController : Controller
    {


        readonly AppDbContext apDB = new AppDbContext();
        
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {   
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Package/AddToCart/5
        public ActionResult AddToCart(string id)
        {
            // Retrieve the album from the database

            var addedPackage = apDB.Package1
                .SingleOrDefault(package => package.PackageID == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedPackage);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(string id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the package to display confirmation

            string item = apDB.Carts
 .Single(item => item.PackageID == id).Packages.PackageNameId;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveModel
            {
                //Message = Server.HtmlEncode(packageName) +
                //    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //GET: /ShoppingCart/CartSummary
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return PartialView(viewModel);
        }
        //public ActionResult CartSummary()
        //{
        //    var cart = ShoppingCart.GetCart(this.HttpContext);

        //    ViewData["CartCount"] = cart.GetCount();
        //    return PartialView("CartSummary");
        //}
    }
}

using System;
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
using ID.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ID.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPackageRepository _packageRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnv;

        public ShoppingCartController(IPackageRepository iPackageRepository, ShoppingCart shoppingCart, AppDbContext Context,
            Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHostEnv)
        {
            _packageRepository = iPackageRepository;
            _shoppingCart = shoppingCart;
            _context = Context;
            this.webHostEnv = webHostEnv;
        }


        public IActionResult Index(ShoppingCartViewModel viewModel)
        {
            _ = _shoppingCart.GetShoppingCartItems();


            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                CartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            //var cart = JsonConvert.DeserializeObject<ShoppingCartViewModel>(HttpContext.Session.GetString("ShoppingCartId"));
            return View(shoppingCartViewModel);
        }

        public IActionResult AddToShoppingCart(string PackageId)
        {
            var selectedPackage = _packageRepository.GetPackage().FirstOrDefault(p => p.PackageId == PackageId);


            if (selectedPackage != null)
            {
                _shoppingCart.AddToCart(selectedPackage, 1);


            }


            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromShoppingCart(string PackageId)
        {
            var selectedPackage = _packageRepository.Package.FirstOrDefault(p => p.PackageId == PackageId);

            if (selectedPackage != null)
            {
                _shoppingCart.RemoveFromCart(selectedPackage);
            }
            return RedirectToAction("Index");
        }

    }

}
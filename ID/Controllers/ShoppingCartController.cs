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


namespace ID.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPackageRepository _packageRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IPackageRepository iPackageRepository, ShoppingCart shoppingCart)
        {
            _packageRepository = iPackageRepository;
            _shoppingCart = shoppingCart;
        }


        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                CartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public IActionResult AddToShoppingCart(string PackageId/*, string PackageNameId, decimal PackagePrice*/)
        {
            var selectedPackage = _packageRepository.GetPackage().FirstOrDefault(p => p.PackageId == PackageId);
            //&&
            //p.PackageNameId == PackageNameId && p.PackagePrice == PackagePrice);

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
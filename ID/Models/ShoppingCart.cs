using ID.Controllers;
using ID.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ID.Models
{
    public partial class ShoppingCart
    {

        private readonly AppDbContext _appDbContext;

        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public string ShoppingCartId { get; set; }

        public List<Cart> ShoppingCartItems { get; set; }


        public static ShoppingCart GetCart(IServiceProvider services)
        {

            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string scartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();

            session.SetString("ShoppingCartId", scartId);

            return new ShoppingCart(context) { ShoppingCartId = scartId };
        }
 
public void AddToCart(Package package, int count)
{
    var shoppingCartItem =
        _appDbContext.Carts.SingleOrDefault(
            s => s.Package.PackageId == package.PackageId && s.ShoppingCartId == ShoppingCartId);

    if (shoppingCartItem == null)
    {
        shoppingCartItem = new Cart
        {
            ShoppingCartId = ShoppingCartId,
            PackageId = package.PackageId,
            Count = 1
        };

        _appDbContext.Carts.Add(shoppingCartItem);
    }
    else
    {
        shoppingCartItem.Count++;
    }
    _appDbContext.SaveChanges();
}

public int RemoveFromCart(Package Package)
{
    var shoppingCartItem =
        _appDbContext.Carts.SingleOrDefault(
            s => s.Package.PackageId == Package.PackageId && s.ShoppingCartId == ShoppingCartId);

    var localAmount = 0;

    if (shoppingCartItem != null)
    {
        if (shoppingCartItem.Count > 1)
        {
            shoppingCartItem.Count--;
            localAmount = shoppingCartItem.Count;
        }
        else
        {
            _appDbContext.Carts.Remove(shoppingCartItem);
        }
    }

    _appDbContext.SaveChanges();

    return localAmount;
}

public List<Cart> GetShoppingCartItems()
{

    return ShoppingCartItems ??
        (ShoppingCartItems =
     _appDbContext.Carts.Where(
    cart => cart.ShoppingCartId == ShoppingCartId)
        .Include(c => c.Package)
        .ToList());


}

public void ClearCart()
{
    var cartItems = _appDbContext
        .Carts
        .Where(cart => cart.ShoppingCartId == ShoppingCartId);

    _appDbContext.Carts.RemoveRange(cartItems);

    _appDbContext.SaveChanges();
}



public decimal GetShoppingCartTotal()
{
    var total = _appDbContext.Carts.Where(c => c.
    ShoppingCartId == ShoppingCartId)
        .Select(c => c.Package.PackagePrice * c.Count).Sum();
    return total;


}

    }
}
   
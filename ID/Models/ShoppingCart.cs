using ID.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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


        // factory method to create shoppingcart from session
        public static ShoppingCart GetCart(IServiceProvider services)
        {

            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string scartId = session.GetString("SCartId") ?? Guid.NewGuid().ToString();

            session.SetString("SCartId", scartId);

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
                    Package = package,
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

        public int RemoveFromCart(Package packages)
        {
            var shoppingCartItem =
                _appDbContext.Carts.SingleOrDefault(
                    s => s.Package.PackageId == packages.PackageId && s.ShoppingCartId == ShoppingCartId);

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
    //readonly AppDbContext apDB = new AppDbContext();
    //string ShoppingCartId { get; set; }
    //public const string CartSessionKey = "CartId";
    //public static ShoppingCart GetCart(HttpContext context)
    //{
    //    var cart = new ShoppingCart();
    //    cart.ShoppingCartId = cart.GetCartId(context);
    //    return cart;
    //}
    //// Helper method to simplify shopping cart calls
    //public static ShoppingCart GetCart(Controller controller)
    //{
    //    return GetCart(controller.HttpContext);
    //}



    //public void AddToCart(Packages packages)
    //{
    //    // Get the matching cart and package instances
    //    var cartItem = apDB.Carts.SingleOrDefault(
    //        c => c.CartId == ShoppingCartId
    //        && c.PackageID == packages.PackageID);

    //    if (cartItem == null)
    //    {
    //        // Create a new cart item if no cart item exists
    //        cartItem = new Cart()
    //        {

    //            PackageID = packages.PackageID,
    //            CartId = ShoppingCartId,
    //            Count = 1,
    //            AddedOn = DateTime.Now
    //        };
    //        apDB.Carts.Add(cartItem);
    //    }
    //    else
    //    {
    //        // If the item does exist in the cart, 
    //        // then add one to the quantity
    //        cartItem.Count++;
    //    }
    //    // Save changes
    //    apDB.SaveChanges();
    //}
    //public int RemoveFromCart(string id)
    //{
    //    // Get the cart
    //    var cartItem = apDB.Carts.SingleOrDefault(
    //        cart => cart.CartId == ShoppingCartId
    //        && cart.PackageID == id);

    //    int itemCount = 0;

    //    if (cartItem != null)
    //    {
    //        if (cartItem.Count > 1)
    //        {
    //            cartItem.Count--;
    //            itemCount = cartItem.Count;
    //        }
    //        else
    //        {
    //            apDB.Carts.Remove(cartItem);
    //        }
    //        // Save changes
    //        apDB.SaveChanges();
    //    }
    //    return itemCount;
    //}
    //public void EmptyCart()
    //{
    //    var cartItems = apDB.Carts.Where(
    //        cart => cart.CartId == ShoppingCartId);

    //    foreach (var cartItem in cartItems)
    //    {
    //        apDB.Carts.Remove(cartItem);
    //    }
    //    // Save changes
    //    apDB.SaveChanges();
    //}

    //internal static object GetCart(object httpContext)
    //{
    //    throw new NotImplementedException();
    //}

    //public List<Cart> GetCartItems()
    //{
    //    return apDB.Carts.Where(
    //        cart => cart.CartId == ShoppingCartId).ToList();
    //}
    //public int GetCount()
    //{
    //    //// Get the count of each item in the cart and sum them up
    //    //int? count = (from cartItems in apDB.Carts
    //    //              where cartItems.CartId == ShoppingCartId
    //    //              select (int?)cartItems.Count).Sum();
    //    //// Return 0 if all entries are null
    //    //return count ?? 0;
    //    return apDB.Carts
    //             .Where(c => c.CartId == ShoppingCartId)
    //             .Select(c => c.Count)
    //             .Sum();
    //}
    //public decimal GetTotal()
    //{

    //    //decimal? total = (from cartItems in apDB.Carts
    //    //                  where cartItems.CartId == ShoppingCartId
    //    //                  select (int?)cartItems.Count*cartItems.packages.PackagePrice).Sum();

    //    //return total ?? decimal.Zero;
    //    decimal total = (from cartItems in apDB.Carts
    //                     where ((cartItems.CartId == ShoppingCartId))
    //                     select cartItems.Count * cartItems.Packages.PackagePrice).FirstOrDefault();
    //    return total;

    //}
    //public int CreateOrder(Order order)
    //{
    //    int orderTotal = 0;

    //    var cartItems = GetCartItems();
    //    // Iterate over the items in the cart, 
    //    // adding the order details for each
    //    foreach (var item in cartItems)
    //    {
    //        var orderDetail = new OrderDetail
    //        {
    //            PackageID = item.PackageID,
    //            OrderId = order.OrderId,
    //            UnitPrice = item.Packages.PackagePrice,
    //            Quantity = item.Count
    //        };
    //        // Set the order total of the shopping cart
    //        orderTotal += (item.Count * item.Packages.PackagePrice);

    //        apDB.OrderDetails.Add(orderDetail);

    //    }
    //    // Set the order's total to the orderTotal count
    //    order.Total = orderTotal;

    //    // Save the order
    //    apDB.SaveChanges();
    //    // Empty the shopping cart
    //    EmptyCart();
    //    // Return the OrderId as the confirmation number
    //    return order.OrderId;
    //}
    //public string GetCartId(HttpContext context)
    //{
    //    if (context.Session.GetString(CartSessionKey) == null)
    //    {
    //        if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
    //        {
    //            context.Session.SetString(CartSessionKey, context.User.Identity.Name);
    //        }
    //        else
    //        {
    //            var tempCartId = Guid.NewGuid();
    //            context.Session.SetString(CartSessionKey, tempCartId.ToString());
    //        }
    //    }

    //    return context.Session.GetString(CartSessionKey);
    //}
    ////We're using HttpContextBase to allow access to cookies.

    //// When a user has logged in, migrate their shopping cart to
    //// be associated with their username
    //public void MigrateCart(string userName)
    //{
    //    var shoppingCart = apDB.Carts.Where(
    //        c => c.CartId == ShoppingCartId);

    //    foreach (Cart item in shoppingCart)
    //    {
    //        item.CartId = userName;
    //    }
    //    apDB.SaveChanges();
    //}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            decimal orderTotal = 0;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Quantity = shoppingCartItem.Count,
                    PackageID = shoppingCartItem.Packages.PackageID,
                    UnitPrice = shoppingCartItem.Packages.PackagePrice,
                    OrderId = order.OrderId
                };

                orderTotal = shoppingCartItem.Count * shoppingCartItem.Packages.PackagePrice;
                _appDbContext.OrderDetails.Add(orderDetail);
            }

            order.Total += orderTotal;

            _appDbContext.SaveChanges();
        }

    }
}

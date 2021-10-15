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
        public IEnumerable<Order> GetOrders()
        {
            return _appDbContext.Orders.ToList();
        }
        public IQueryable<Order> GetAll()
        {
            return _appDbContext.Orders.AsQueryable();
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
                    PackageId = shoppingCartItem.Package.PackageId,
                    UnitPrice = shoppingCartItem.Package.PackagePrice,
                    OrderId = order.OrderId
                };

                orderTotal = shoppingCartItem.Count * shoppingCartItem.Package.PackagePrice;
                _appDbContext.OrderDetails.Add(orderDetail);
            }

            order.Total += orderTotal;

            _appDbContext.SaveChanges();
        }

    }
}

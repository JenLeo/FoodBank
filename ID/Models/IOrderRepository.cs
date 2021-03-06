using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);

        IEnumerable<Order> GetOrders();

        IQueryable<Order> GetAll();
    }
}

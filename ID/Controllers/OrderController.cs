using ID.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnv;


        public OrderController(
            IOrderRepository orderRepository,
            AppDbContext Context,
            Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHostEnv
         )
        {
            _orderRepository = orderRepository;
            _context = Context;
            this.webHostEnv = webHostEnv;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var items = _context.Orders.ToList();
            return View(items);
        }

        //public async Task<IActionResult> Index(string searchString, string searchLocation)
        //{
        //    var or = from o in _context.Orders
        //             select o;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        or = or.Where(o => o.SupplierName.Contains(searchString));
        //    }
        //    if (!String.IsNullOrEmpty(searchLocation))
        //    {
        //        or = or.Where(o => o.SupplierAddress.Contains(searchLocation));
        //    }
        //    return View(await or.ToListAsync());
        //}
    }
}

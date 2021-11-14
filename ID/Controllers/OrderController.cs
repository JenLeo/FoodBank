using ID.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index(string searchString, string searchLocation)
        {
            var or = from o in _context.Orders
                     select o;

            if (!String.IsNullOrEmpty(searchString))
            {
                or = or.Where(o => o.FirstName.Contains(searchString) ||
                o.LastName.Contains(searchString) ||
                o.PhoneNumber.Contains(searchString) ||
                o.Email.Contains(searchString) ||
                o.OrderDate.ToString().Contains(searchString) ||
                o.OrderStatus.Contains(searchString)

                );
            }
            if (!String.IsNullOrEmpty(searchLocation))
            {
                or = or.Where(o => o.AddressLine1.Contains(searchLocation) ||
                o.AddressLine2.Contains(searchLocation) ||
                o.City.Contains(searchLocation) ||
                o.Country.Contains(searchLocation));
            }
            return View(await or.ToListAsync());

        }

        

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _ord = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);
            if (_ord == null)
            {
                return NotFound();
            }

            return View(_ord);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _or = await _context.Orders.FindAsync(id);
            if (_or == null)
            {
                return NotFound();
            }
            return View(_or);
        }



        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //OrderId,FirstName,LastName,AddressLine1," +
           // "City,Country,PhoneNumber,Email,OrderDate,
        public async Task<IActionResult> Edit(string id, [Bind("OrderId,FirstName,LastName,AddressLine1," +
            "City,Country,PhoneNumber,Email,OrderDate,OrderStatus")] Order _or)
        {
            if (id != _or.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_or);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(_or.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(_or
                );
        }
        private void PopulateOrganisationsDropDownList(object selectedOrganisation = null)
        {
            var organisationsQuery = from d in _context.Organisations
                                   orderby d.OrganisationName
                                   select d;
            ViewBag.OrganisationId = new SelectList(organisationsQuery.AsNoTracking(), "OrganisationId", "OrganisationName", selectedOrganisation);
        }

        private bool ItemExists(string orderId)
        {
            throw new NotImplementedException();
        }


        // GET: OrderController/Delete/5

        public async Task<IActionResult> Delete(string id)
        {

            var _ord = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);

            return View(_ord);
        }

        // POST: OrderController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string Id)
        {
            var _ord = await _context.Orders.FindAsync(Id);
            _context.Orders.Remove(_ord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

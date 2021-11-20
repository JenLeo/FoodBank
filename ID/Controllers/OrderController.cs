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

        public async Task<IActionResult> Index(string searchString, string searchLocation, string sortOrder, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["StatusSortParm"] = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "OrderDate";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "OrganisationName"; ;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var ord = _context.Orders
       .Include(o => o.Organisation)
       .Include(c => c.Cart)
       //.ThenInclude(p => p.Package)

       .AsNoTracking();

            if (!String.IsNullOrEmpty(searchString))
            {
                ord = ord.Where(o => o.FirstName.Contains(searchString) ||
                o.LastName.Contains(searchString) ||
                o.PhoneNumber.Contains(searchString) ||
                o.Email.Contains(searchString) ||
                o.OrderDate.ToString().Contains(searchString) ||
                o.OrderStatus.Contains(searchString)

                );
            }
            if (!String.IsNullOrEmpty(searchLocation))
            {
                ord = ord.Where(o => o.AddressLine1.Contains(searchLocation) ||
                o.AddressLine2.Contains(searchLocation) ||
                o.City.Contains(searchLocation) ||
                o.Country.Contains(searchLocation));
            }

            switch (sortOrder)
            {
                case "status_desc":
                    ord.OrderByDescending(o => o.OrderStatus);
                    break;
                case "Date":
                    ord.OrderBy(o => o.OrderDate);
                    break;
                case "date_desc":
                    ord.OrderByDescending(o => o.OrderDate);
                    break;
                case "Name":
                    ord.OrderBy(o => o.Organisation.OrganisationName);
                    break;
                case "name_desc":
                    ord.OrderByDescending(o => o.Organisation.OrganisationName);
                    break;
                default:
                    ord.OrderBy(o => o.OrderStatus);
                    break;
            }

            int pageSize = 5;

            return View(await PaginatedList<Order>.CreateAsync(ord.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _order = await _context.Orders
                   .Include(o => o.Organisation)
                   .Include(c => c.Cart)
                    //.ThenInclude(p => p.Package)
                    .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (_order == null)
            {
                return NotFound();
            }

            return View(_order);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var _or = await _context.Orders
       .AsNoTracking()
       .FirstOrDefaultAsync(m => m.OrderId == id);

            if (_or == null)
            {
                return NotFound();
            }
            PopulateOrganisationsDropDownList(_or.OrganisationId);
            return View(_or);
        }

        // POST: OrderController/Edit/5

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderToUpdate = await _context.Orders
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (await TryUpdateModelAsync<Order>(orderToUpdate, "",
                o => o.OrderDate, o => o.CartId,
                o => o.OrderStatus, o => o.OrganisationId,
                o => o.FirstName, o => o.LastName,
                o => o.AddressLine1, o => o.AddressLine2,
                o => o.City, o => o.PhoneNumber,
                o => o.Email, o => o.Country))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {

                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateOrganisationsDropDownList(orderToUpdate.OrganisationId);
            return View(orderToUpdate
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
            if (id == null)
            {
                return NotFound();
            }

            var _order = await _context.Orders
                        .Include(c => c.Organisation)
                        .Include(o => o.Cart)
                    
                    .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (_order == null)
            {
                return NotFound();
            }

            return View(_order);
            
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

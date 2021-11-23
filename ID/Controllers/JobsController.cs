using ID.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Controllers
{
    public class JobsController : Controller
    {

        private readonly IOrderRepository _orderRepository;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnv;


        public JobsController(
            IOrderRepository orderRepository,
            AppDbContext Context,
            Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHostEnv
         )
        {
            _orderRepository = orderRepository;
            _context = Context;
            this.webHostEnv = webHostEnv;
        }

        public async Task <IActionResult> Index(string searchString, string sortOrder, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["StatusSortParm"] = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["SupplierSortParm"] = sortOrder == "Supplier" ? "supplier_desc" : "Supplier";
            ViewData["SupplierAddressSortParm"] = sortOrder == "SupplierAddress" ? "supplier_address_desc" : "SupplierAddress";
            ViewData["OrganisationSortParm"] = sortOrder == "Organisation" ? "organisation_desc" : "Organisation";
            ViewData["OrganisationAddressSortParm"] = sortOrder == "OrganisationAddress" ? "organisation_address_desc" : "OrganisationAddress";
            

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var orderdetails = from o in _context.OrderDetails
       .Include(c => c.Order)
       .ThenInclude(r => r.Organisation)
       .Include(p => p.Packages)
       .ThenInclude(s => s.Supplier)
       .AsNoTracking()
       select o;

            if (!String.IsNullOrEmpty(searchString))
            {
                orderdetails = orderdetails.Where(o =>
                o.Packages.Supplier.SupplierName.Contains(searchString) ||
                o.Packages.Supplier.SupplierAddress.Contains(searchString) ||
                o.Order.Organisation.OrganisationName.Contains(searchString) ||
                o.Order.Organisation.OrganisationAddress.ToString().Contains(searchString) ||
                o.OrderStatus.Contains(searchString)

                );
            }
            

            switch (sortOrder)
            {
                case "status_desc":
                    orderdetails = orderdetails.OrderByDescending(o => o.OrderStatus);
                    break;
                case "Date":
                    orderdetails = orderdetails.OrderBy(o => o.Order.OrderDate);
                    break;
                case "date_desc":
                    orderdetails = orderdetails.OrderByDescending(o => o.Order.OrderDate);
                    break;
                case "Supplier":
                    orderdetails = orderdetails.OrderBy(o => o.Packages.Supplier.SupplierName);
                    break;
                case "supplier_desc":
                    orderdetails = orderdetails.OrderByDescending(o => o.Packages.Supplier.SupplierName);
                    break;
                case "SupplierAddress":
                    orderdetails = orderdetails.OrderBy(o => o.Packages.Supplier.SupplierAddress);
                    break;
                case "supplier_address_desc":
                    orderdetails = orderdetails.OrderByDescending(o => o.Packages.Supplier.SupplierAddress);
                    break;
                case "Organisation":
                    orderdetails = orderdetails.OrderBy(o => o.Order.Organisation.OrganisationName);
                    break;
                case "organisation_desc":
                    orderdetails = orderdetails.OrderByDescending(o => o.Order.Organisation.OrganisationName);
                    break;
                case "OrganisationAddress":
                    orderdetails = orderdetails.OrderBy(o => o.Order.Organisation.OrganisationAddress);
                    break;
                case "organisation_address_desc":
                    orderdetails = orderdetails.OrderByDescending(o => o.Order.Organisation.OrganisationAddress);
                    break;
                default:
                    orderdetails = orderdetails.OrderBy(o => o.OrderStatus);
                    break;
            }

            int pageSize = 5;

            return View(await PaginatedList<OrderDetail>.CreateAsync(orderdetails.AsNoTracking(), pageNumber ?? 1, pageSize));

          
            
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _order = await _context.OrderDetails
       .Include(c => c.Order)
       .ThenInclude(o => o.Organisation)
       .Include(p => p.Packages)
       .ThenInclude(s => s.Supplier)
       .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OrderDetailId == id);
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
            var _or = await _context.OrderDetails
       .AsNoTracking()
       .FirstOrDefaultAsync(m => m.OrderDetailId == id);

            if (_or == null)
            {
                return NotFound();
            }
       
            return View(_or);
        }

        // POST: Jobs/Edit/5

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderDetailToUpdate = await _context.OrderDetails
                .FirstOrDefaultAsync(o => o.OrderDetailId == id);

            if (await TryUpdateModelAsync<OrderDetail>(orderDetailToUpdate, "",
                o => o.OrderId, o => o.PackageId,
                o => o.Quantity, o => o.UnitPrice,
                o => o.OrderStatus
                ))
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
            
            return View(orderDetailToUpdate
                );
        }
      

        // GET: JobsController/Delete/5

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _order = await _context.OrderDetails
                .Include(c => c.Order)
       .ThenInclude(o => o.Organisation)
       .Include(p => p.Packages)
       .ThenInclude(s => s.Supplier)
                    .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OrderDetailId == id);
            if (_order == null)
            {
                return NotFound();
            }

            return View(_order);

        }

        // POST: JobsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string Id)
        {
            var _ord = await _context.OrderDetails.FindAsync(Id);
            _context.OrderDetails.Remove(_ord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}

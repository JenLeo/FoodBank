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

        public async Task <IActionResult> Index()
        {
            var orderdetails = _context.OrderDetails
       .Include(c => c.Order)
       .ThenInclude(o => o.Organisation)
       .Include(p => p.Packages)
       .ThenInclude(s => s.Supplier)
       .AsNoTracking();
            return View(await orderdetails.ToListAsync());
            
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

        // POST: Package/Edit/5

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
      

        // GET: OrderDetailController/Delete/5

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _order = await _context.OrderDetails
                    .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OrderDetailId == id);
            if (_order == null)
            {
                return NotFound();
            }

            return View(_order);

        }

        // POST: OrderDetailController/Delete/5
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

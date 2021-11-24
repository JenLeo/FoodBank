using ID.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace ID.Controllers
{
    public class SupplierController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnv;

        public SupplierController(IConfiguration configuration, IOptions<GlobalData> globalData, AppDbContext Context, IWebHostEnvironment webHostEnv)
        {
            _context = Context;
            try
            {
                _context.Database.EnsureCreated();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            this.webHostEnv = webHostEnv;
        }
        // GET: SupplierController
        [HttpGet]
        public IActionResult Index()
        {
            var items = _context.Suppliers.ToList();
            return View(items);
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var sp = from s in _context.Suppliers
                     select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                sp = sp.Where(s => s.SupplierName.Contains(searchString) ||
                s.SupplierAddress.Contains(searchString));
            }
            
            return View(await sp.ToListAsync());
        }
        // GET: SupplierController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _sp = await _context.Suppliers.FirstOrDefaultAsync(m => m.SupplierId == id);
            if (_sp == null)
            {
                return NotFound();
            }

            return View(_sp);
        }

        // GET: SupplierController/Create
        [Authorize/*(Roles = "Admin")*/]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SupplierViewModel vm)
        {
            string stringFileName = UploadFile(vm);
            var sp = new Supplier
            {
                SupplierId = vm.SupplierId,
                SupplierName = vm.SupplierName,
                SupplierAddress = vm.SupplierAddress,
                Pic = stringFileName
            };
            _context.Suppliers.Add(sp);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        private string UploadFile(SupplierViewModel vm)
        {
            string fileName = null;
            if (vm.Pic != null)
            {
                string uploadDir = Path.Combine(webHostEnv.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + vm.Pic.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.Pic.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _sp = await _context.Suppliers.FindAsync(id);
            if (_sp == null)
            {
                return NotFound();
            }
            return View(_sp);
        }



        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SupplierId,SupplierName,SupplierAddress,Pic")] Supplier _sp)
        {
            if (id != _sp.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_sp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(_sp.SupplierId))
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
            return View(_sp);
        }

        private bool ItemExists(string supplierId)
        {
            throw new NotImplementedException();
        }


        // GET: SupplierController/Delete/5
      
        public async Task<IActionResult> Delete(string id)
        {
           
            var _sp = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.SupplierId == id);
          

            return View(_sp);
        }

        // POST: SupplierController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string Id)
        {
            var _sp = await _context.Suppliers.FindAsync(Id);
            _context.Suppliers.Remove(_sp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
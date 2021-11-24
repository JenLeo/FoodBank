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
    public class OrganisationController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnv;

        public OrganisationController(IConfiguration configuration, IOptions<GlobalData> globalData, AppDbContext Context, IWebHostEnvironment webHostEnv)
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
        // GET: OrganisationController
        [HttpGet]
        public IActionResult Index()
        {
            var items = _context.Organisations.ToList();
            return View(items);
        }
       
        public async Task<IActionResult> Index(string searchString)
        {
            var org = from o in _context.Organisations
                      select o;

            if (!String.IsNullOrEmpty(searchString))
            {
                org = org.Where(s => s.OrganisationName.Contains(searchString) || s.OrganisationAddress.Contains(searchString));
            }
          
            return View(await org.ToListAsync());
        }
        // GET: OrganisationController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _org = await _context.Organisations.FirstOrDefaultAsync(m => m.OrganisationId == id);
            if (_org == null)
            {
                return NotFound();
            }

            return View(_org);
        }

        // GET: FoodServiceController/Create
        [Authorize/*(Roles = "Admin")*/]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(OrganisationViewModel vm)
        {
            string stringFileName = UploadFile(vm);
            var org = new Organisation
            {
                OrganisationId = vm.OrganisationId,
                OrganisationName = vm.OrganisationName,
                OrganisationAddress = vm.OrganisationAddress,
                Pic = stringFileName
            };
            _context.Organisations.Add(org);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        private string UploadFile(OrganisationViewModel vm)
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

            var _or = await _context.Organisations.FindAsync(id);
            if (_or == null)
            {
                return NotFound();
            }
            return View(_or);
        }



        // POST: FoodServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OrganisationId,OrganisationName,OrganisationAddress,Pic")] Organisation _or)
        {
            if (id != _or.OrganisationId)
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
                    if (!ItemExists(_or.OrganisationId))
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

        private bool ItemExists(string organisationID)
        {
            throw new NotImplementedException();
        }


        // GET: FoodServiceController/Delete/5

        public async Task<IActionResult> Delete(string id)
        {

            var _org = await _context.Organisations
                .FirstOrDefaultAsync(m => m.OrganisationId == id);
           
            return View(_org);
        }

        // POST: FoodServiceController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string Id)
        {
            var _org = await _context.Organisations.FindAsync(Id);
            _context.Organisations.Remove(_org);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

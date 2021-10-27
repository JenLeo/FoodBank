using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using ID.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ID.Controllers
{
   
    public class PackageController : Controller
    {
        private readonly IPackageRepository _PackageRepository;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnv;

      
        public PackageController(
            IPackageRepository packageRepository,
            AppDbContext Context,
            Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHostEnv
         )
        {
            _PackageRepository = packageRepository;
            _context = Context;
            this.webHostEnv = webHostEnv;
        }

        public async Task<IActionResult> Index(string searchString, string sortOrder, string currentFilter, int? pageNumber)
        {


            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["TypeSortParm"] = sortOrder == "Type" ? "type_desc" : "Type";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";



            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var pks = from p in _context.Packages
                      select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                pks = pks.Where(p => p.PackageNameId.Contains(searchString) || p.PackageDetail.Contains(searchString)
                || p.PackageType.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    pks.OrderByDescending(p => p.PackageNameId);
                    break;
                case "Type":
                    pks.OrderBy(p => p.PackageType);
                    break;
                case "type_desc":
                    pks.OrderByDescending(p => p.PackageType);
                    break;
                case "Price":
                    pks.OrderBy(p => p.PackagePrice);
                    break;
                case "price_desc":
                    pks.OrderByDescending(p => p.PackagePrice);
                    break;
                default:
                    pks.OrderBy(p => p.PackageNameId);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Package>.CreateAsync(pks.AsNoTracking(), pageNumber ?? 1, pageSize));


            ////set value into session key
            //HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(pks));
            return View(pks);

        }

        //GET: Package/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _pack = await _context.Packages.FirstOrDefaultAsync(m => m.PackageId == id);
            if (_pack == null)
            {
                return NotFound();
            }

            return View(_pack);
        }



       // GET: PackageController/Create
       //[Authorize/*(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PackageController/Create
        [HttpPost]
        public IActionResult Create(PackageViewModel vm)
            {
           
            string stringFileName = UploadFile(vm);
            var package = new Package
            {
                PackageId = vm.PackageId,
                PackageNameId = vm.PackageNameId,
                PackageDetail = vm.PackageDetail,
                PackageType = vm.PackageType,
                PackagePrice = vm.PackagePrice,
                Pic = stringFileName
            };
            _context.Packages.Add(package);
            _context.SaveChanges();

           return RedirectToAction("Index");
            }

        private string UploadFile(PackageViewModel vm)
        {
            string fileName = null;
            if (vm.Pic!=null)
            {
                string uploadDir = Path.Combine(webHostEnv.WebRootPath,"images");
                fileName = Guid.NewGuid().ToString()+ vm.Pic.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath,FileMode.Create))
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

            var _pk = await _context.Packages.FindAsync(id);
            if (_pk == null)
            {
                return NotFound();
            }
            return View(_pk);
        }

        // POST: Package/Edit/5

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(String id, [Bind("PackageId,PackageNameId,PackageDetail,PackageType,PackagePrice,Pic")] Package _pkg)
        {
            
            if (id != _pkg.PackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(_pkg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(_pkg.PackageId))
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
            return View(_pkg
                );
        }
       
        // GET: Package/Delete/5

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _package = await _context.Packages
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (_package == null)
            {
                return NotFound();
            }

            return View(_package);
        }

        // POST: Package/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string Id)
        {
            var _package = await _context.Packages.FindAsync(Id);
            _context.Packages.Remove(_package);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(string id)
        {
            return _context.Packages.Any(e => e.PackageId == id);
        }
    }
}

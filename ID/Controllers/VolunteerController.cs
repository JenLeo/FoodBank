using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ID.Controllers
{
    [Authorize/*(Roles="Admin")*/]
    public class VolunteerController : Controller
    {
        private readonly AppDbContext _context;

        public VolunteerController(IConfiguration configuration, IOptions<GlobalData> globalData, AppDbContext Context)
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
        }

        [HttpGet]
        // GET: VolunteerController
        
        public ActionResult Index()
        {
            return View(_context.Volunteer.ToList());
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var vols = from v in _context.Volunteer
                        select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                vols = vols.Where(s => s.VolFName.Contains(searchString));
            }

            return View(await vols.ToListAsync());
        }

        // GET: Volunteer/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var _vol = await _context.Volunteer.FirstOrDefaultAsync(m => m.VolunteerId == id);
            if (_vol == null)
            {
                return NotFound();
            }

            return View(_vol);
        }
       

        // GET: VolunteerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VolunteerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VolunteerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VolunteerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VolunteerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VolunteerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

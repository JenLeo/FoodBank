using ID.Models;
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
                vols = vols.Where(v => v.VolFName.Contains(searchString) || v.VolLName.Contains(searchString)
                || v.VolunteerId.Contains(searchString));
            }

            return View(await vols.ToListAsync());
        }

        // GET: Volunteer/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: VolunteerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Volunteers volunteer)
        {

            var vol = new Volunteers
            {
                VolunteerId = volunteer.VolunteerId,
                VolFName = volunteer.VolFName,
                VolLName = volunteer.VolLName,
               
            };
            _context.Volunteer.Add(vol);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _vol = await _context.Volunteer.FindAsync(id);
            if (_vol == null)
            {
                return NotFound();
            }
            return View(_vol);
        }

        // POST: VolunteerrController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VolunteerId,VolFName,VolLName")] Volunteers volunteer)
        {
            if (id != volunteer.VolunteerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volunteer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(volunteer.VolunteerId))
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
            return View(volunteer);
        }

        private bool ItemExists(string volunteerId)
        {
            throw new NotImplementedException();
        }

        // GET: VolunteerController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {

            var vol = await _context.Volunteer
                .FirstOrDefaultAsync(v => v.VolunteerId == id);


            return View(vol);
        }

        // POST: VolunteerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string Id)
        {
            var vol = await _context.Volunteer.FindAsync(Id);
            _context.Volunteer.Remove(vol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

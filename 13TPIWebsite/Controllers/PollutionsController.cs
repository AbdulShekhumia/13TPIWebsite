using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalDatabase.Models;
using _13TPIWebsite.Data;
using X.PagedList;

namespace _13TPIWebsite.Controllers
{
    public class PollutionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PollutionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pollutions
        public ActionResult Index(string searchTerm, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CountrySortParm = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "";
            
            if (searchTerm != null)
            {
                page = 1;
            }
            else
            {
                searchTerm = currentFilter;
            }

            ViewBag.CurrentFilter = searchTerm;

            var pollutions = from s in _context.Pollution
                              select s;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                {
                    pollutions = pollutions.Where(s => s.Country.Contains(searchTerm));
                }

            }
            switch (sortOrder)
            {
                case "country_desc":
                    pollutions = pollutions.OrderByDescending(s => s.Country);
                    break;
                default:
                    pollutions = pollutions.OrderBy(s => s.Country);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(pollutions.ToPagedList(pageNumber, pageSize));

        }
        // GET: Pollutions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollution = await _context.Pollution
                .FirstOrDefaultAsync(m => m.PollutionID == id);
            if (pollution == null)
            {
                return NotFound();
            }

            return View(pollution);
        }

        // GET: Pollutions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pollutions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PollutionID,Country,AvgTemperature,Population,PollutionLevels,CarbonEmissions")] Pollution pollution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pollution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pollution);
        }

        // GET: Pollutions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollution = await _context.Pollution.FindAsync(id);
            if (pollution == null)
            {
                return NotFound();
            }
            return View(pollution);
        }

        // POST: Pollutions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PollutionID,Country,AvgTemperature,Population,PollutionLevels,CarbonEmissions")] Pollution pollution)
        {
            if (id != pollution.PollutionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pollution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PollutionExists(pollution.PollutionID))
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
            return View(pollution);
        }

        // GET: Pollutions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollution = await _context.Pollution
                .FirstOrDefaultAsync(m => m.PollutionID == id);
            if (pollution == null)
            {
                return NotFound();
            }

            return View(pollution);
        }

        // POST: Pollutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pollution = await _context.Pollution.FindAsync(id);
            _context.Pollution.Remove(pollution);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PollutionExists(int id)
        {
            return _context.Pollution.Any(e => e.PollutionID == id);
        }
    }
}

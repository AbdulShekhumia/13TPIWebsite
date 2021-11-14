using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalDatabase.Models;
using _13TPIWebsite.Data;
using Microsoft.AspNetCore.Authorization;

namespace _13TPIWebsite.Controllers
{
    [Authorize]
    public class WorkspacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkspacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Workspaces
        public async Task<IActionResult> Index()
        {
            return View(await _context.Workspaces.ToListAsync());
        }

        // GET: Workspaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workspaces = await _context.Workspaces
                .FirstOrDefaultAsync(m => m.WorkspacesID == id);
            if (workspaces == null)
            {
                return NotFound();
            }

            return View(workspaces);
        }

        // GET: Workspaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workspaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkspacesID,WorkspacesName,Phone,Email,Street,Suburb,City,ZipCode")] Workspaces workspaces)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workspaces);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workspaces);
        }

        // GET: Workspaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workspaces = await _context.Workspaces.FindAsync(id);
            if (workspaces == null)
            {
                return NotFound();
            }
            return View(workspaces);
        }

        // POST: Workspaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkspacesID,WorkspacesName,Phone,Email,Street,Suburb,City,ZipCode")] Workspaces workspaces)
        {
            if (id != workspaces.WorkspacesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workspaces);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkspacesExists(workspaces.WorkspacesID))
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
            return View(workspaces);
        }

        // GET: Workspaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workspaces = await _context.Workspaces
                .FirstOrDefaultAsync(m => m.WorkspacesID == id);
            if (workspaces == null)
            {
                return NotFound();
            }

            return View(workspaces);
        }

        // POST: Workspaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workspaces = await _context.Workspaces.FindAsync(id);
            _context.Workspaces.Remove(workspaces);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkspacesExists(int id)
        {
            return _context.Workspaces.Any(e => e.WorkspacesID == id);
        }
    }
}

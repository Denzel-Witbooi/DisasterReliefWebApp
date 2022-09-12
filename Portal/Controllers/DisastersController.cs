using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;

namespace Portal.Controllers
{
    public class DisastersController : Controller
    {
        private readonly DisasterReliefContext _context;

        public DisastersController(DisasterReliefContext context)
        {
            _context = context;
        }

        // GET: Disasters
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var disasters = from d in _context.Disasters
                            select d;

            int pageSize = 3;
            return View(await PaginatedList<Disaster>.CreateAsync(disasters.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Disasters/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disaster = await _context.Disasters
                .Include(d => d.Goods)
                    .ThenInclude(g => g.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DisasterID == id);
            if (disaster == null)
            {
                return NotFound();
            }

            return View(disaster);
        }

        // GET: Disasters/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("StartDate,EndDate,Description,Location")] Disaster disaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(disaster);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                //Log the error
                ModelState.AddModelError("", "Unable to save changes. " +
                           "Try again, and if the problem persists " +
                           "see your system administrator.");
            }
            return View(disaster);
        }

        // GET: Disasters/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disaster = await _context.Disasters.FindAsync(id);
            if (disaster == null)
            {
                return NotFound();
            }
            return View(disaster);
        }

        // POST: Disasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisasterID,StartDate,EndDate,Description,Location")] Disaster disaster)
        {
            if (id != disaster.DisasterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisasterExists(disaster.DisasterID))
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
            return View(disaster);
        }

        // GET: Disasters/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disaster = await _context.Disasters
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DisasterID == id);
            if (disaster == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                      "Delete failed. Try again, and if the problem persists " +
                      "see your system administrator.";
            }

            return View(disaster);
        }

        // POST: Disasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disaster = await _context.Disasters.FindAsync(id);
            _context.Disasters.Remove(disaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisasterExists(int id)
        {
            return _context.Disasters.Any(e => e.DisasterID == id);
        }
    }
}

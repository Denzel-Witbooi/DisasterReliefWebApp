using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models.Donation;

namespace Portal.Controllers
{
    public class MonetariesController : Controller
    {
        private readonly DisasterReliefContext _context;

        public MonetariesController(DisasterReliefContext context)
        {
            _context = context;
        }

        // GET: Monetaries
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Monetaries.ToListAsync());
        }

        // GET: Monetaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monetary = await _context.Monetaries
                .FirstOrDefaultAsync(m => m.MonetaryID == id);
            if (monetary == null)
            {
                return NotFound();
            }

            return View(monetary);
        }

        // GET: Monetaries/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monetaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MonetaryID,DonationDate,DonationAmount,DonorName")] Monetary monetary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monetary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monetary);
        }

        // GET: Monetaries/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monetary = await _context.Monetaries.FindAsync(id);
            if (monetary == null)
            {
                return NotFound();
            }
            return View(monetary);
        }

        // POST: Monetaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MonetaryID,DonationDate,DonationAmount,DonorName")] Monetary monetary)
        {
            if (id != monetary.MonetaryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monetary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonetaryExists(monetary.MonetaryID))
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
            return View(monetary);
        }

        // GET: Monetaries/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monetary = await _context.Monetaries
                .FirstOrDefaultAsync(m => m.MonetaryID == id);
            if (monetary == null)
            {
                return NotFound();
            }

            return View(monetary);
        }

        // POST: Monetaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monetary = await _context.Monetaries.FindAsync(id);
            _context.Monetaries.Remove(monetary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonetaryExists(int id)
        {
            return _context.Monetaries.Any(e => e.MonetaryID == id);
        }
    }
}

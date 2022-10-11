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
    public class GoodsPurchasesController : Controller
    {
        private readonly DisasterReliefContext _context;

        public decimal totalDonation { get; set; }

        public GoodsPurchasesController(DisasterReliefContext context)
        {
            _context = context;
        }

        // GET: GoodsPurchases
        [Authorize]
        public async Task<IActionResult> Index()
        {
            totalDonation = _context.Monetaries
               .Sum(m => m.DonationAmount);


           
            ViewBag.totalDonation = totalDonation.ToString("C0");
            var disasterReliefContext = _context.GoodsPurchases.Include(g => g.Disaster).Include(g => g.Monetary);

            return View(await disasterReliefContext.ToListAsync());
        }

        // GET: GoodsPurchases/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsPurchase = await _context.GoodsPurchases
                .Include(g => g.Disaster)
                .Include(g => g.Monetary)
                .FirstOrDefaultAsync(m => m.GoodsPurchaseId == id);
            if (goodsPurchase == null)
            {
                return NotFound();
            }

            return View(goodsPurchase);
        }

        // GET: GoodsPurchases/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["DisasterId"] = new SelectList(_context.Disasters, "DisasterID", "Description");
            ViewData["MonetaryId"] = new SelectList(_context.Monetaries, "MonetaryID", "MonetaryID");
            return View();
        }

        // POST: GoodsPurchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoodsPurchaseId,DisasterId,MonetaryId,Description,purchaseAmount")] GoodsPurchase goodsPurchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsPurchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisasterId"] = new SelectList(_context.Disasters, "DisasterID", "Description", goodsPurchase.DisasterId);
            ViewData["MonetaryId"] = new SelectList(_context.Monetaries, "MonetaryID", "MonetaryID", goodsPurchase.MonetaryId);
            return View(goodsPurchase);
        }

        // GET: GoodsPurchases/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsPurchase = await _context.GoodsPurchases.FindAsync(id);
            if (goodsPurchase == null)
            {
                return NotFound();
            }
            ViewData["DisasterId"] = new SelectList(_context.Disasters, "DisasterID", "Description", goodsPurchase.DisasterId);
            ViewData["MonetaryId"] = new SelectList(_context.Monetaries, "MonetaryID", "MonetaryID", goodsPurchase.MonetaryId);
            return View(goodsPurchase);
        }

        // POST: GoodsPurchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GoodsPurchaseId,DisasterId,MonetaryId,Description,purchaseAmount")] GoodsPurchase goodsPurchase)
        {
            if (id != goodsPurchase.GoodsPurchaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsPurchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsPurchaseExists(goodsPurchase.GoodsPurchaseId))
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
            ViewData["DisasterId"] = new SelectList(_context.Disasters, "DisasterID", "Description", goodsPurchase.DisasterId);
            ViewData["MonetaryId"] = new SelectList(_context.Monetaries, "MonetaryID", "MonetaryID", goodsPurchase.MonetaryId);
            return View(goodsPurchase);
        }

        // GET: GoodsPurchases/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsPurchase = await _context.GoodsPurchases
                .Include(g => g.Disaster)
                .Include(g => g.Monetary)
                .FirstOrDefaultAsync(m => m.GoodsPurchaseId == id);
            if (goodsPurchase == null)
            {
                return NotFound();
            }

            return View(goodsPurchase);
        }

        // POST: GoodsPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goodsPurchase = await _context.GoodsPurchases.FindAsync(id);
            _context.GoodsPurchases.Remove(goodsPurchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsPurchaseExists(int id)
        {
            return _context.GoodsPurchases.Any(e => e.GoodsPurchaseId == id);
        }
    }
}

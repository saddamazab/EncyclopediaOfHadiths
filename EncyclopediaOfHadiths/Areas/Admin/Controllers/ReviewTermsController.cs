#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EncyclopediaOfHadiths.Models;

namespace EncyclopediaOfHadiths.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReviewTermsController : Controller
    {
        private readonly EncyclopediaOfHadithsContext _context;

        public ReviewTermsController(EncyclopediaOfHadithsContext context)
        {
            _context = context;
        }

        // GET: Admin/ReviewTerms
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReviewTerms.ToListAsync());
        }

        // GET: Admin/ReviewTerms/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewTerm = await _context.ReviewTerms
                .FirstOrDefaultAsync(m => m.ReviewTermId == id);
            if (reviewTerm == null)
            {
                return NotFound();
            }

            return View(reviewTerm);
        }

        // GET: Admin/ReviewTerms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ReviewTerms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewTermId,ReviewTermTitle")] ReviewTerm reviewTerm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewTerm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reviewTerm);
        }

        // GET: Admin/ReviewTerms/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewTerm = await _context.ReviewTerms.FindAsync(id);
            if (reviewTerm == null)
            {
                return NotFound();
            }
            return View(reviewTerm);
        }

        // POST: Admin/ReviewTerms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("ReviewTermId,ReviewTermTitle")] ReviewTerm reviewTerm)
        {
            if (id != reviewTerm.ReviewTermId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewTerm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewTermExists(reviewTerm.ReviewTermId))
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
            return View(reviewTerm);
        }

        // GET: Admin/ReviewTerms/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewTerm = await _context.ReviewTerms
                .FirstOrDefaultAsync(m => m.ReviewTermId == id);
            if (reviewTerm == null)
            {
                return NotFound();
            }

            return View(reviewTerm);
        }

        // POST: Admin/ReviewTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var reviewTerm = await _context.ReviewTerms.FindAsync(id);
            _context.ReviewTerms.Remove(reviewTerm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewTermExists(byte id)
        {
            return _context.ReviewTerms.Any(e => e.ReviewTermId == id);
        }
    }
}

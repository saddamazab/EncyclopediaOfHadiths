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
    public class NarratorsChainsController : Controller
    {
        private readonly EncyclopediaOfHadithsContext _context;

        public NarratorsChainsController(EncyclopediaOfHadithsContext context)
        {
            _context = context;
        }

        // GET: Admin/NarratorsChains
        public async Task<IActionResult> Index()
        {
            var encyclopediaOfHadithsContext = _context.NarratorsChains.Include(n => n.Hadith).Include(n => n.Narrator).Include(n => n.NarratorLevelNavigation);
            return View(await encyclopediaOfHadithsContext.ToListAsync());
        }

        // GET: Admin/NarratorsChains/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narratorsChain = await _context.NarratorsChains
                .Include(n => n.Hadith)
                .Include(n => n.Narrator)
                .Include(n => n.NarratorLevelNavigation)
                .FirstOrDefaultAsync(m => m.NarratorsChainId == id);
            if (narratorsChain == null)
            {
                return NotFound();
            }

            return View(narratorsChain);
        }

        // GET: Admin/NarratorsChains/Create
        public IActionResult Create()
        {
            ViewData["HadithId"] = new SelectList(_context.Hadiths, "HadithId", "HadithText");
            ViewData["NarratorId"] = new SelectList(_context.Narrators, "NarratorId", "NarratorName");
            ViewData["NarratorLevel"] = new SelectList(_context.NarratorLevels, "NarratorLevelId", "NarratorLevelId");
            return View();
        }

        // POST: Admin/NarratorsChains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NarratorsChainId,NarratorId,NarratorLevel,HadithId")] NarratorsChain narratorsChain)
        {
            if (ModelState.IsValid)
            {
                _context.AddRange(narratorsChain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HadithId"] = new SelectList(_context.Hadiths, "HadithId", "HadithText", narratorsChain.HadithId);
            ViewData["NarratorId"] = new SelectList(_context.Narrators, "NarratorId", "NarratorName", narratorsChain.NarratorId);
            ViewData["NarratorLevel"] = new SelectList(_context.NarratorLevels, "NarratorLevelId", "NarratorLevelId", narratorsChain.NarratorLevel);
            return View(narratorsChain);
        }

        // GET: Admin/NarratorsChains/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narratorsChain = await _context.NarratorsChains.FindAsync(id);
            if (narratorsChain == null)
            {
                return NotFound();
            }
            ViewData["HadithId"] = new SelectList(_context.Hadiths, "HadithId", "HadithText", narratorsChain.HadithId);
            ViewData["NarratorId"] = new SelectList(_context.Narrators, "NarratorId", "NarratorName", narratorsChain.NarratorId);
            ViewData["NarratorLevel"] = new SelectList(_context.NarratorLevels, "NarratorLevelId", "NarratorLevelId", narratorsChain.NarratorLevel);
            return View(narratorsChain);
        }

        // POST: Admin/NarratorsChains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("NarratorsChainId,NarratorId,NarratorLevel,HadithId")] NarratorsChain narratorsChain)
        {
            if (id != narratorsChain.NarratorsChainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(narratorsChain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NarratorsChainExists(narratorsChain.NarratorsChainId))
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
            ViewData["HadithId"] = new SelectList(_context.Hadiths, "HadithId", "HadithText", narratorsChain.HadithId);
            ViewData["NarratorId"] = new SelectList(_context.Narrators, "NarratorId", "NarratorName", narratorsChain.NarratorId);
            ViewData["NarratorLevel"] = new SelectList(_context.NarratorLevels, "NarratorLevelId", "NarratorLevelId", narratorsChain.NarratorLevel);
            return View(narratorsChain);
        }

        // GET: Admin/NarratorsChains/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narratorsChain = await _context.NarratorsChains
                .Include(n => n.Hadith)
                .Include(n => n.Narrator)
                .Include(n => n.NarratorLevelNavigation)
                .FirstOrDefaultAsync(m => m.NarratorsChainId == id);
            if (narratorsChain == null)
            {
                return NotFound();
            }

            return View(narratorsChain);
        }

        // POST: Admin/NarratorsChains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var narratorsChain = await _context.NarratorsChains.FindAsync(id);
            _context.NarratorsChains.Remove(narratorsChain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NarratorsChainExists(long id)
        {
            return _context.NarratorsChains.Any(e => e.NarratorsChainId == id);
        }
    }
}

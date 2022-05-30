#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EncyclopediaOfHadiths.Models;

namespace EncyclopediaOfHadiths.Controllers
{
    public class HadithsController : Controller
    {
        private readonly EncyclopediaOfHadithsContext _context;

        public HadithsController(EncyclopediaOfHadithsContext context)
        {
            _context = context;
        }

        // GET: Hadiths
        public async Task<IActionResult> Index()
        {
            ViewBag.Term = _context.HadithsReviews
                .Include(h => h.ReviewTerm)
                .Include(h => h.Hadith)
                .Where(x=>x.UserId == "22862f54-7424-4394-b6dc-8f62645338e9")
                .ToList();

            ViewBag.NarratorsChain = _context.NarratorsChains
                .Include(h => h.Narrator)
                //.Include(h => h.NarratorLevel)
                .ToList();

            ViewBag.Hashtag = _context.HadithsHashTags
               .Include(h=>h.HashTag)
               .Include(h => h.Hadith)
               .Where(x => x.UserId == "22862f54-7424-4394-b6dc-8f62645338e9")
               .ToList();

            var encyclopediaOfHadithsContext = _context.Hadiths.Include(h => h.Collection).Include(h => h.HadithType);
            return View(await encyclopediaOfHadithsContext.ToListAsync());
        }

        // GET: Hadiths/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hadith = await _context.Hadiths
                .Include(h => h.Collection)
                .Include(h => h.HadithType)
                .FirstOrDefaultAsync(m => m.HadithId == id);
            if (hadith == null)
            {
                return NotFound();
            }

            return View(hadith);
        }

        // GET: Hadiths/Create
        public IActionResult Create()
        {
            ViewData["CollectionId"] = new SelectList(_context.Collections, "CollectionId", "CollectionAuthor");
            ViewData["HadithTypeId"] = new SelectList(_context.HadithTypes, "HadithTypeId", "HadithTypeTitle");
            return View();
        }

        // POST: Hadiths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HadithId,CollectionId,HadithNo,HadithText,VocabsExplain,ReviewTermId,HadithTypeId,NarratorsChainId")] Hadith hadith)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hadith);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollectionId"] = new SelectList(_context.Collections, "CollectionId", "CollectionAuthor", hadith.CollectionId);
            ViewData["HadithTypeId"] = new SelectList(_context.HadithTypes, "HadithTypeId", "HadithTypeTitle", hadith.HadithTypeId);
            return View(hadith);
        }

        // GET: Hadiths/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hadith = await _context.Hadiths.FindAsync(id);
            if (hadith == null)
            {
                return NotFound();
            }
            ViewData["CollectionId"] = new SelectList(_context.Collections, "CollectionId", "CollectionAuthor", hadith.CollectionId);
            ViewData["HadithTypeId"] = new SelectList(_context.HadithTypes, "HadithTypeId", "HadithTypeTitle", hadith.HadithTypeId);
            return View(hadith);
        }

        // POST: Hadiths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("HadithId,CollectionId,HadithNo,HadithText,VocabsExplain,ReviewTermId,HadithTypeId,NarratorsChainId")] Hadith hadith)
        {
            if (id != hadith.HadithId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hadith);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HadithExists(hadith.HadithId))
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
            ViewData["CollectionId"] = new SelectList(_context.Collections, "CollectionId", "CollectionAuthor", hadith.CollectionId);
            ViewData["HadithTypeId"] = new SelectList(_context.HadithTypes, "HadithTypeId", "HadithTypeTitle", hadith.HadithTypeId);
            return View(hadith);
        }

        // GET: Hadiths/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hadith = await _context.Hadiths
                .Include(h => h.Collection)
                .Include(h => h.HadithType)
                .FirstOrDefaultAsync(m => m.HadithId == id);
            if (hadith == null)
            {
                return NotFound();
            }

            return View(hadith);
        }

        // POST: Hadiths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var hadith = await _context.Hadiths.FindAsync(id);
            _context.Hadiths.Remove(hadith);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HadithExists(long id)
        {
            return _context.Hadiths.Any(e => e.HadithId == id);
        }
    }
}

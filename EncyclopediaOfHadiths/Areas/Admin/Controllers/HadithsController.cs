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
    public class HadithsController : Controller
    {
        private readonly EncyclopediaOfHadithsContext _context;

        public HadithsController(EncyclopediaOfHadithsContext context)
        {
            _context = context;
        }

        // GET: Admin/Hadiths
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["HadithSortParm"] = String.IsNullOrEmpty(sortOrder) ? "HadithNo_desc" : "";
            ViewData["HadithTypeSortParm"] = sortOrder == "HadithType_" ? "HadithType_desc" : "HadithType_";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var hadiths = from s in _context.Hadiths.Include(h => h.Collection).Include(h => h.HadithType)
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                hadiths = hadiths.Where(s => s.HadithNo.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "HadithNo_desc":
                    hadiths = hadiths.OrderByDescending(s => s.HadithNo);
                    break;
                case "HadithType_":
                    hadiths = hadiths.OrderBy(s => s.HadithType);
                    break;
                case "HadithType_desc":
                    hadiths = hadiths.OrderByDescending(s => s.HadithType);
                    break;
                default:
                    hadiths = hadiths.OrderBy(s => s.HadithNo);
                    break;
            }

            int pageSize = 3;
            //var encyclopediaOfHadithsContext = _context.Hadiths.Include(h => h.Collection).Include(h => h.HadithType);
            //await encyclopediaOfHadithsContext.ToListAsync()
            
            return View(await PaginatedList<Hadith>.CreateAsync(hadiths.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Admin/Hadiths/Details/5
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

        // GET: Admin/Hadiths/Create
        public IActionResult Create()
        {
            ViewData["ReviewTermId"] = new SelectList(_context.ReviewTerms, "ReviewTermId", "ReviewTermTitle");
            ViewData["CollectionId"] = new SelectList(_context.Collections, "CollectionId", "CollectionTitle");
            ViewData["HadithTypeId"] = new SelectList(_context.HadithTypes, "HadithTypeId", "HadithTypeTitle");
            return View();
        }

        // POST: Admin/Hadiths/Create
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

        // GET: Admin/Hadiths/Edit/5
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

        // POST: Admin/Hadiths/Edit/5
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

        // GET: Admin/Hadiths/Delete/5
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

        // POST: Admin/Hadiths/Delete/5
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

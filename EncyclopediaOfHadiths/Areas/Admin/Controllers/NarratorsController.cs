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
    public class NarratorsController : Controller
    {
        private readonly EncyclopediaOfHadithsContext _context;

        public NarratorsController(EncyclopediaOfHadithsContext context)
        {
            _context = context;
        }

        // GET: Admin/Narrators
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NarratorSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Narrator_desc" : "";
            ViewData["NarratorDiedSortParm"] = sortOrder == "NarratorDied_" ? "NarratorDied_desc" : "NarratorDied_";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var narratrs = from s in _context.Narrators
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                narratrs = narratrs.Where(s => s.NarratorName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Narrator_desc":
                    narratrs = narratrs.OrderByDescending(s => s.NarratorName);
                    break;
                case "NarratorDied_":
                    narratrs = narratrs.OrderBy(s => s.NarratorDied);
                    break;
                case "NarratorDied_desc":
                    narratrs = narratrs.OrderByDescending(s => s.NarratorDied);
                    break;
                default:
                    narratrs = narratrs.OrderBy(s => s.NarratorName);
                    break;
            }

            int pageSize = 3;
            //await _context.Narrators.ToListAsync()
            return View(await PaginatedList<Narrator>.CreateAsync(narratrs.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Admin/Narrators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narrator = await _context.Narrators
                .FirstOrDefaultAsync(m => m.NarratorId == id);
            if (narrator == null)
            {
                return NotFound();
            }

            return View(narrator);
        }

        // GET: Admin/Narrators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Narrators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NarratorId,NarratorName,NarratorWasBorned,NarratorDied,NarratorInfo,NarratorNote")] Narrator narrator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(narrator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(narrator);
        }

        // GET: Admin/Narrators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narrator = await _context.Narrators.FindAsync(id);
            if (narrator == null)
            {
                return NotFound();
            }
            return View(narrator);
        }

        // POST: Admin/Narrators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NarratorId,NarratorName,NarratorWasBorned,NarratorDied,NarratorInfo,NarratorNote")] Narrator narrator)
        {
            if (id != narrator.NarratorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(narrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NarratorExists(narrator.NarratorId))
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
            return View(narrator);
        }

        // GET: Admin/Narrators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narrator = await _context.Narrators
                .FirstOrDefaultAsync(m => m.NarratorId == id);
            if (narrator == null)
            {
                return NotFound();
            }

            return View(narrator);
        }

        // POST: Admin/Narrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var narrator = await _context.Narrators.FindAsync(id);
            _context.Narrators.Remove(narrator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NarratorExists(int id)
        {
            return _context.Narrators.Any(e => e.NarratorId == id);
        }
    }
}

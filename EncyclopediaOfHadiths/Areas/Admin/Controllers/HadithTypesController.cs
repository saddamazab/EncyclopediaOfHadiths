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
    public class HadithTypesController : Controller
    {
        private readonly EncyclopediaOfHadithsContext _context;

        public HadithTypesController(EncyclopediaOfHadithsContext context)
        {
            _context = context;
        }

        // GET: Admin/HadithTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.HadithTypes.ToListAsync());
        }

        // GET: Admin/HadithTypes/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hadithType = await _context.HadithTypes
                .FirstOrDefaultAsync(m => m.HadithTypeId == id);
            if (hadithType == null)
            {
                return NotFound();
            }

            return View(hadithType);
        }

        // GET: Admin/HadithTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HadithTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HadithTypeId,HadithTypeTitle,HadithTypeNote")] HadithType hadithType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hadithType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hadithType);
        }

        // GET: Admin/HadithTypes/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hadithType = await _context.HadithTypes.FindAsync(id);
            if (hadithType == null)
            {
                return NotFound();
            }
            return View(hadithType);
        }

        // POST: Admin/HadithTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("HadithTypeId,HadithTypeTitle,HadithTypeNote")] HadithType hadithType)
        {
            if (id != hadithType.HadithTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hadithType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HadithTypeExists(hadithType.HadithTypeId))
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
            return View(hadithType);
        }

        // GET: Admin/HadithTypes/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hadithType = await _context.HadithTypes
                .FirstOrDefaultAsync(m => m.HadithTypeId == id);
            if (hadithType == null)
            {
                return NotFound();
            }

            return View(hadithType);
        }

        // POST: Admin/HadithTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var hadithType = await _context.HadithTypes.FindAsync(id);
            _context.HadithTypes.Remove(hadithType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HadithTypeExists(byte id)
        {
            return _context.HadithTypes.Any(e => e.HadithTypeId == id);
        }
    }
}

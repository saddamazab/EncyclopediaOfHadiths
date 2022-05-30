using EncyclopediaOfHadiths.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EncyclopediaOfHadiths.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SaveController : Controller
    {
        private readonly EncyclopediaOfHadithsContext _context;

        public SaveController(EncyclopediaOfHadithsContext context)
        {
            _context = context;
        }
        //
        // GET: /Save/

        public ActionResult BulkData()
        {
            ViewBag.narrators =new SelectList(_context.Narrators,"NarratorId", "NarratorName") ;
            ViewBag.levels = new SelectList(_context.NarratorLevels, "NarratorLevelId", "NarratorLevelId");
            ViewBag.hadiths = new SelectList(_context.Hadiths, "HadithId", "HadithNo");

            // This is only for show by default one row for insert data to the database
            List<NarratorsChain> ci = new List<NarratorsChain> { new NarratorsChain { NarratorsChainId = 0, NarratorId = 0, HadithId = 0 ,NarratorLevel=0} };
            return View(ci);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BulkData(List<NarratorsChain> ci)
        {
            if (ModelState.IsValid)
            {
                using (EncyclopediaOfHadithsContext dc = new EncyclopediaOfHadithsContext())
                {
                    foreach (var i in ci)
                    {
                        dc.NarratorsChains.Add(i);
                    }
                    dc.SaveChanges();
                    ViewBag.Message = "Data successfully saved!";
                    ModelState.Clear();
                    ci = new List<NarratorsChain> { new NarratorsChain { NarratorsChainId = 0, NarratorId = 0, HadithId = 0, NarratorLevel = 0 } };
                }
            }
            return View(ci);
        }

    }
}


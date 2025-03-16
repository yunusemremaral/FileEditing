using ImdbRandomMovie.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ImdbRandomMovie.Controllers
{
    public class TitleRatingsController : Controller
    {
        private readonly ImdbContext _context;

        public TitleRatingsController(ImdbContext context)
        {
            _context = context;
        }

        // GET: Yeni veri ekleme formunu gösterir
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yeni veriyi kaydeder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TitleRatingsFiltered model)
        {
            if (ModelState.IsValid)
            {
                _context.TitleRatingsFiltereds.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Listeleme sayfasına yönlendirme
            }
            return View(model);
        }
    }

}

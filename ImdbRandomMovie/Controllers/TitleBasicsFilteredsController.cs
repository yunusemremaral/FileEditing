using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImdbRandomMovie.Controllers
{
    public class TitleBasicsFilteredsController : Controller
    {
        private readonly ImdbDbContext _context;

        public TitleBasicsFilteredsController(ImdbDbContext context)
        {
            _context = context;
        }

        // GET: TitleBasicsFiltereds
        public async Task<IActionResult> Index()
        {
            var titles = await _context.TitleBasicsFiltereds.Where(a => a.AverageRating > 80 && a.NumVotes > 50000).Take(200).ToListAsync();
            return View(titles);
        }

        // GET: TitleBasicsFiltereds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TitleBasicsFiltereds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TitleBasicsFiltered titleBasicsFiltered)
        {
            if (ModelState.IsValid)
            {
                _context.Add(titleBasicsFiltered);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(titleBasicsFiltered);
        }

        public async Task<IActionResult> FindMovies()
        {
            // Veritabanındaki tüm türleri çek
            var genres = new List<string>
    {
        "Action",
        "Adventure",
        "Animation",
        "Biography",
        "Comedy",
        "Crime",
        "Documentary",
        "Drama",
        "Family",
        "Fantasy",
        "History",
        "Horror",
        "Music",
        "Musical",
        "Mystery",
        "Romance",
        "Sci-Fi",
        "Sport",
        "Thriller",
        "War",
        "Western"
    };

            // Türleri ViewBag'e ekle
            ViewBag.Genres = genres;

            return View(new List<TitleBasicsFiltered>());
        }
        [HttpPost]
        public async Task<IActionResult> FindMovies(List<string> selectedGenres)
        {
            // Seçilen türlere göre filmleri filtrele
            var movies = await _context.TitleBasicsFiltereds
                .Where(m => selectedGenres.All(genre => m.Genres.Contains(genre)))
                .ToListAsync();

            // Türleri ViewBag'e ekle (formun tekrar render edilmesi için)
            ViewBag.Genres = new List<string>
    {
        "Action",
        "Adventure",
        "Animation",
        "Biography",
        "Comedy",
        "Crime",
        "Documentary",
        "Drama",
        "Family",
        "Fantasy",
        "History",
        "Horror",
        "Music",
        "Musical",
        "Mystery",
        "Romance",
        "Sci-Fi",
        "Sport",
        "Thriller",
        "War",
        "Western"
    };

            return View(movies);
        }


    }

}

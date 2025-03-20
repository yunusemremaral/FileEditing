using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImdbRandomMovie.Controllers
{
    public class MovieController : Controller
    {
        private readonly ImdbDbContext _context;

        public MovieController(ImdbDbContext context)
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
        

        // GET: TitleBasicsFiltereds/FindMovies
        public async Task<IActionResult> FindMovies()
        {
            ViewBag.Genres = GetGenreList();
            ViewBag.MinYear = 1900; // Default değerler
            ViewBag.MaxYear = 2024;
            return View(new List<TitleBasicsFiltered>());
        }

        // POST: TitleBasicsFiltereds/FindMovies
        [HttpPost]
        public async Task<IActionResult> FindMovies(
            List<string> selectedGenres,
            int minYear ,  // Default değerleri ayarla
            int maxYear )
        {
            // Yıl sınır kontrolleri
            minYear = Math.Clamp(minYear, 1800, 2050);
            maxYear = Math.Clamp(maxYear, minYear, 2050);
            // Validasyonlar
            if (selectedGenres?.Count > 3)
            {
                ModelState.AddModelError("", "En fazla 3 tür seçebilirsiniz");
                return await ReloadForm(selectedGenres, minYear, maxYear);
            }

            // Sorgu oluşturma
            var query = _context.TitleBasicsFiltereds.AsQueryable();

            // Tür Filtresi
            if (selectedGenres != null && selectedGenres.Any())
            {
                query = query.Where(m => selectedGenres.All(genre => m.Genres.Contains(genre)));
            }

            // Yıl Filtresi
            query = query.Where(m => m.StartYear >= minYear && m.StartYear <= maxYear);

            var movies = await query.ToListAsync();

            return await ReloadForm(selectedGenres, minYear, maxYear, movies);
        }

        private async Task<IActionResult> ReloadForm(
            List<string> selectedGenres,
            int minYear,
            int maxYear,
            List<TitleBasicsFiltered> movies = null)
        {
            ViewBag.Genres = GetGenreList();
            ViewBag.MinYear = minYear;
            ViewBag.MaxYear = maxYear;
            ViewBag.SelectedGenres = selectedGenres ?? new List<string>();
            return View(movies ?? new List<TitleBasicsFiltered>());
        }

        private List<string> GetGenreList()
        {
            return new List<string>
        {
            "Action", "Adventure", "Animation", "Biography", "Comedy",
            "Crime", "Documentary", "Drama", "Family", "Fantasy",
            "History", "Horror", "Music", "Musical", "Mystery",
            "Romance", "Sci-Fi", "Sport", "Thriller", "War", "Western"
        };
        }

    }

}

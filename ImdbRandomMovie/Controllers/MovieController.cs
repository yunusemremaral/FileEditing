using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
            var titles = await _context.TitleBasicsFiltereds
                .Where(a => a.AverageRating > 80 && a.NumVotes > 50000)
                .Take(200)
                .ToListAsync();
            return View(titles);
        }

        // GET: TitleBasicsFiltereds/FindMovies
        public async Task<IActionResult> FindMovies()
        {
            ViewBag.Genres = GetGenreList();
            // Varsayılan filtre değerleri
            ViewBag.MinYear = 1894;
            ViewBag.MaxYear = 2025;
            ViewBag.MinRating = "0.1"; // 👈 String olarak ata
            ViewBag.MaxRating = "9.9";
            ViewBag.VotesFilter = "all"; // Oy filtresinde varsayılan: tümü (0 ve üzeri)
            return View(new List<TitleBasicsFiltered>());
        }

        // POST: TitleBasicsFiltereds/FindMovies
        [HttpPost]
        public async Task<IActionResult> FindMovies(
            List<string> selectedGenres,
            int minYear,
            int maxYear,
    [FromForm(Name = "minRating")] string minRatingStr,
    [FromForm(Name = "maxRating")] string maxRatingStr,
            string votesFilter)
        {
            double minRating =10* double.Parse(minRatingStr, CultureInfo.InvariantCulture);
            double maxRating =10* double.Parse(maxRatingStr, CultureInfo.InvariantCulture);


            // Yıl sınır kontrolleri
            minYear = Math.Clamp(minYear, 1894, 2025);
            maxYear = Math.Clamp(maxYear, minYear, 2025);

            // Tür seçim kontrolü: en fazla 3 seçime izin
            if (selectedGenres?.Count > 3)
            {
                ModelState.AddModelError("", "En fazla 3 tür seçebilirsiniz");
                return await ReloadForm(selectedGenres, minYear, maxYear, minRating, maxRating, votesFilter);
            }

            // Sorgu oluşturma
            var query = _context.TitleBasicsFiltereds.AsQueryable();

            // Tür filtresi: seçilen tüm türlerin mevcut olması gerekiyor
            if (selectedGenres != null && selectedGenres.Any())
            {
                query = query.Where(m => selectedGenres.All(genre => m.Genres.Contains(genre)));
            }

            // Yıl filtresi
            query = query.Where(m => m.StartYear >= minYear && m.StartYear <= maxYear);

            // IMDb Puanı filtresi
            query = query.Where(m => m.AverageRating >= minRating && m.AverageRating <= maxRating);

            // NUM VOTES filtresi
            switch (votesFilter)
            {
                case "low":
                    query = query.Where(m => m.NumVotes < 1000);
                    break;
                case "medium":
                    query = query.Where(m => m.NumVotes >= 1000 && m.NumVotes < 10000);
                    break;
                case "high":
                    query = query.Where(m => m.NumVotes >= 10000);
                    break;
                default:
                    // "all" seçiliyse ek filtre yok
                    break;
            }

            var movies = await query.ToListAsync();

            return await ReloadForm(selectedGenres, minYear, maxYear, minRating, maxRating, votesFilter, movies);
        }

        private async Task<IActionResult> ReloadForm(
            List<string> selectedGenres,
            int minYear,
            int maxYear,
            double minRating,
            double maxRating,
            string votesFilter,
            List<TitleBasicsFiltered> movies = null)
        {
            ViewBag.Genres = GetGenreList();
            ViewBag.MinYear = minYear;
            ViewBag.MaxYear = maxYear;
            ViewBag.MinRating = minRating.ToString("0.0", CultureInfo.InvariantCulture); // 👈 Double → String
            ViewBag.MaxRating = maxRating.ToString("0.0", CultureInfo.InvariantCulture);
            ViewBag.VotesFilter = votesFilter;
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

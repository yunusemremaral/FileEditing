using ImdbRandomMovie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbRandomMovie.Controllers
{
    public class MovieController : Controller
    {
        private readonly ImdbContext _context;

        public MovieController(ImdbContext context)
        {
            _context = context;
        }

        // Movie sayfasını render edecek GET aksiyonu
        public async Task<IActionResult> Movie(string genre, int minRating = 7, int minVotes = 10000)
        {
            // Filtreleme sorgusunu başlatıyoruz
            var query = from rating in _context.TitleRatingsFiltereds
                        join basics in _context.TitleBasicsFiltereds
                        on rating.Tconst equals basics.Tconst
                        where rating.NumVotes > minVotes // Min oy sayısı filtresi
                              && rating.AverageRating > minRating // Min rating filtresi
                        select new MovieRatingModel
                        {
                            Title = basics.PrimaryTitle,
                            Votes = rating.NumVotes.Value,
                            Rating = rating.AverageRating.Value,
                            Genres = basics.Genres
                        };

            // Genre filtresi ekliyoruz
            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(m => m.Genres.Contains(genre));
            }

            // Sıralama işlemi ve sadece ilk 10 kaydı alma
            var movies = await query.OrderBy(m => Guid.NewGuid()) // Rastgele sıralama
                                    .Take(10)
                                    .ToListAsync();

            // Filmleri view'e gönderiyoruz
            return View(new MovieFilterViewModel
            {
                Movies = movies,
                Genre = genre,
                MinRating = minRating,
                MinVotes = minVotes
            });
        }
    }
}

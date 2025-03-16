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

        public async Task<IActionResult> Movie()
        {
            var movies = await (from rating in _context.TitleRatingsFiltereds
                                join basics in _context.TitleBasicsFiltereds
                                on rating.Tconst equals basics.Tconst
                                where rating.NumVotes > 10000 && rating.AverageRating > 80
                                && basics.Genres.Contains("Action") // Burada genre içeriğini kontrol ediyoruz
                                orderby Guid.NewGuid() // Rastgele sıralama
                                select new MovieRatingModel
                                {
                                    Title = basics.PrimaryTitle,
                                    Votes = rating.NumVotes.Value,
                                    Rating = rating.AverageRating.Value
                                })
                                .Take(10)
                                .ToListAsync();

            return View(movies);
        }




    }
}

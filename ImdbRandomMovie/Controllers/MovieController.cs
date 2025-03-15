using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImdbRandomMovie.Models;

namespace YourNamespace.Controllers
{
    public class MovieController : Controller
    {
        private readonly string _connectionString;

        public MovieController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // GET: /Movie/Index
        public async Task<IActionResult> Index()
        {
            var movies = await GetMoviesAsync();
            return View(movies);
        }

        // Movie verilerini çekmek için Dapper kullanacağız
        private async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Movies"; // Movies tablosu adını kendi veritabanınıza göre değiştirin
                var movies = await connection.QueryAsync<Movie>(query);
                return movies;
            }
        }
    }
}

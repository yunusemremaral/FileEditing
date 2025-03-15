// MovieController.cs
using Dapper;
using ImdbRandomMovie.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ImdbRandomMovie.Controllers
{
    public class MovieController : Controller
    {
        private readonly string _connectionString;

        public MovieController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 20)
        {
            // SQL Sorgusu (En kritik kısım)
            var sql = @"
                SELECT 
                    b.tconst AS Tconst,
                    b.primaryTitle AS PrimaryTitle,
                    b.startYear AS StartYear,
                    b.genres AS Genres,
                    r.averageRating AS AverageRating,
                    c.directors AS Directors
                FROM 
                    [title.basics.filtered] b
                LEFT JOIN 
                    [title.ratings.filtered] r ON b.tconst = r.tconst
                LEFT JOIN 
                    [title.crew.filtered] c ON b.tconst = c.tconst
                ORDER BY 
                    r.averageRating DESC
                OFFSET 
                    @Offset ROWS 
                FETCH NEXT 
                    @PageSize ROWS ONLY";

            using (var connection = new SqlConnection(_connectionString))
            {
                // Timeout'u 120 saniyeye çıkarıyoruz
                var command = new CommandDefinition(
                    sql,
                    new { Offset = (page - 1) * pageSize, PageSize = pageSize },
                    commandTimeout: 120
                );

                var movies = await connection.QueryAsync<MovieViewModel>(command);
                return View(movies);
            }
        }
    }
}
// MovieController.cs
using Dapper;
using ImdbRandomMovie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

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
            var model = await _context.TitleRatingsFiltereds.Take(5).ToListAsync();
            return View(model);
        }
    }
}
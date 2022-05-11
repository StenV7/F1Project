using F1Lib.ViewModels;
using F1Project.Data;
using F1Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace F1Project.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // GET: Result
        public async Task<IActionResult> Index()
        {
            var SeasonRaces = //SeasonRaces storage variabele die Result.Year en Result.Racenumber.Count laat zien via ViewModel
            _context.SeasonVMs.OrderBy(s => s.Year);

            return View(SeasonRaces);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
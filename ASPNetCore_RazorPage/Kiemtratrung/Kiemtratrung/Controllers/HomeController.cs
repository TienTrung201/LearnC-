using Kiemtratrung.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Kiemtratrung.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QLBongDaContext _context;
        public HomeController(ILogger<HomeController> logger, QLBongDaContext context)
        {
            _context = context;

            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
       
            var products = _context.Cauthus.ToList();
            return View(products);
        }
        public IActionResult Category(string maclb)
        {
            var products = _context.Cauthus.Where(l => l.CauLacBoId == maclb).ToList();
            return View(products);
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
using Microsoft.AspNetCore.Mvc;
using PhamTrungKien.Models;
using System.Diagnostics;

namespace PhamTrungKien.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly QLBongDaContext _context;

		public HomeController(ILogger<HomeController> logger, QLBongDaContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			var products = _context.Cauthus.Where(ct=>ct.ViTri=="DF").ToList();
			return View(products);
		}
		public IActionResult Category(string svdID)
		{
			var products = (from svd in _context.Sanvandongs
							join clb in _context.Caulacbos on svd.SanVanDongId equals clb.SanVanDongId
							join ct in _context.Cauthus on clb.CauLacBoId equals ct.CauLacBoId
							where svd.SanVanDongId == svdID
							select ct).ToList();

            return View(products);
		}

        public IActionResult CtCLB(string svdID)
        {
            var products = (from svd in _context.Sanvandongs
                            join clb in _context.Caulacbos on svd.SanVanDongId equals clb.SanVanDongId
                            join ct in _context.Cauthus on clb.CauLacBoId equals ct.CauLacBoId
                            where svd.SanVanDongId == svdID
                            select ct).ToList();

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
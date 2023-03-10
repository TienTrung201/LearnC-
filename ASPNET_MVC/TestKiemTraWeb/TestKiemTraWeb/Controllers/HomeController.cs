using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestKiemTraWeb.Models;
using X.PagedList;

namespace TestKiemTraWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QLBanVaLiContext _context;
        public HomeController(ILogger<HomeController> logger,QLBanVaLiContext context)
        {
            _context = context;

			_logger = logger;
        }

        public IActionResult Index(int? page)
        {
            var currentPage = page ?? 1;
            var totalItemsPerPage = 10;
            
            var products=_context.TDanhMucSps.ToList();
            var pagedProduct=products.ToPagedList(currentPage, totalItemsPerPage);
            return View(pagedProduct);

		}
        public IActionResult ProductDetail(string? id)
        {
            List<TAnhSp> imgProduct = _context.TAnhSps.Where(p => p.MaSp == id).ToList();
            var product = _context.TDanhMucSps.Where(p => p.MaSp == id).FirstOrDefault();
            List<TDanhMucSp> spCungLoai = _context.TDanhMucSps.Where(p => p.MaLoai == product.MaLoai).ToList();

			ViewBag.imgProduct = imgProduct;

			ViewBag.spCungLoai = spCungLoai;
			return View(product);
        }
        public IActionResult Category(string loai)
        {
            var products = _context.TDanhMucSps.Where(l => l.MaLoai == loai).ToList();
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NguyenTienTrung.Models;
using System.Diagnostics;
using X.PagedList;

namespace NguyenTienTrung.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QLBanVaLiContext _context;
        public HomeController(ILogger<HomeController> logger, QLBanVaLiContext context)
        {
            _context = context;

            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
        
            var products = _context.TDanhMucSps.ToList();
 
            return View(products);
        }

        public IActionResult Cate

        public IActionResult Privacy()
        {
            return View();
        }
        /*
         public IActionResult Index(int? page)
        {
            var currentPage = page ?? 1;
            var totalItemsPerPage = 10;
            
            var products=_context.TDanhMucSps.ToList();
            var pagedProduct=products.ToPagedList(currentPage, totalItemsPerPage);
            return View(pagedProduct);

		}*/

        public IActionResult ProductDetail(string? id)
        {
            List<TAnhSp> imgProduct = _context.TAnhSps.Where(p => p.MaSp == id).ToList();

            var product= _context.TDanhMucSps.Where(p =>p.MaSp == id).FirstOrDefault();
               ViewBag.imgProduct = imgProduct;

            return View(product);
        }
         
        public IActionResult Category(string chatlieu)
        {
            var products = _context.TDanhMucSps.Where(l => l.MaChatLieu == chatlieu).ToList();
            return View(products);
        }
        

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
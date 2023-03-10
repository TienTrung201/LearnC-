using InitProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace InitProject.Controllers
{
    //[Route("ten/[Action]")]// như này thì đi vào action không cần thiết lập bên dưới
    //[Route("ten-controller")]// cái này mới đi đến cái bên dưới// nếu thiết lập ở đây thì các action phải thiết lập
    public class FirstController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ProductService  ProductService;
        public FirstController(ILogger<HomeController> logger , ProductService _ProductService)
        {
            ProductService=_ProductService;
            _logger = logger;
        }

        public IActionResult Index(string name){
            // return Content("đây là controller","text/plain");
            // return Json(
            //     new {
            //         iphone="iphoneX",
            //         price=200
            //     }
            // );
            if(string.IsNullOrEmpty(name))
                name="tientrung";
            
            // return View(name);
            return View("xinchao",(object)name);//nếu nó là chuỗi thì bị hiểu nhầm là cái cshtml

        }

        public IActionResult MoveUrl(string name){
            // neeus laf đưuòng dẫn bên ngoài thì sử dụng Redirect
            var url1="https://www.google.com";
            var url= Url.Action("Index","First");
            return LocalRedirect(url);// di chuyeenr vaof controller
            // return Redirect(url1);

        }
        //Order =2 độ uuw tiên bằng 2
        // name có thể sử dụng dc trong cshtml
        [Route("sanpham/[Action]/{id:int}",Order =1,Name ="linktruycap")]// có nghĩa là phải truy cập sanpham/ViewProduct/2 thì mới truy cập được
        [Route("sanpham/[Action].html/{id:int}")]// có nghĩa là phải truy cập sanpham/ViewProduct.html/2 thì mới truy cập được
       // [Route("sanpham/[controller]/[Action]/{id:int}")]// có nghĩa là phải truy cập sanpham/First/ViewProduct/2 thì mới truy cập được
        [Route("[controller]-[Action]/{id:int}")]// có nghĩa là phải truy cập /First-ViewProduct/2 thì mới truy cập được

        [Route("xemsanpham/{id:int}")]
        [AcceptVerbs("POST","GET")] // chỉ truy cập post,get
        [HttpPost("/truycappost")]
        [HttpGet("/truycapget")]
        public IActionResult ViewProduct(int? id){
            var product = ProductService.Where(p => p.Id == id).FirstOrDefault();
            if(product==null){
                TempData["Thongbao"]="San pham này khong ton tai";
                return Redirect(Url.Action("Index","Home"));
            }
            //model
           // return View(product);//sử dụng Model để truyền dữ liệu
            //model

            // return Content($"san pham ID ={id} name ={product.Name} description = {product.Description}");
            ViewBag.product=product;
            //Viewdaata
            ViewData["Product"] = product;
            return View();
            // ViewData

            
        }
    }
}
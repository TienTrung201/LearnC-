using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace RazorpageWebapp
{
    public class ProductView:PageModel
    {
        public ProductListService productService{set;get;}
        private readonly ILogger<ProductView> _logger;
        public Product product { get; set; }
        public ProductView(ILogger<ProductView> logger, ProductListService _productListService)
        {
            productService=_productListService;
            _logger = logger;
        }
        // public void OnGet(int? id){
        //     if(id!=null){
        //         product=productService.FindProduct(id.Value);
        //         ViewData["sanpham"]=$"San pham {id.Value}";
        //     }else{
        //         ViewData["sanpham"]="Danh sách sản phẩm";
        //     }
        // }
        //https://localhost:5001/producview/1?/sanpham=1&name=conlon
          public void OnGet(int? id,[Bind("Id","Name"/*chỉ tìm od va name*/)]Product sanpham){
            if(id!=null){
                product=productService.FindProduct(id.Value);
                ViewData["sanpham"]=$"San pham {id.Value} Ten: {sanpham.Name} Id: {sanpham.Id}";
            }else{
                ViewData["sanpham"]="Danh sách sản phẩm";
            }
        }
        public void OnGetLastProduct(){
            ViewData["sanpham"]="San pham cuoi";
                product=productService.getAllProducts().LastOrDefault();

        }
        public IActionResult OnGetRemoveAll(){
            productService.getAllProducts().Clear();
            return RedirectToPage("ProductView");
        }
        public IActionResult OnpostDelete(int? id){
            product=productService.FindProduct(id.Value);
            if(product!=null){
                productService.getAllProducts().Remove(product);
            }
            return RedirectToAction("ProductView");
        }
    }
}
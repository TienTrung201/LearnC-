using System.Collections.Generic;
using System;
// using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.Extensions.Options;

namespace RazorpageWebapp
{
    // [ViewComponent(Name ="ProductBox")]
    public class ProductBoxComponent:ViewComponent
    {

        ProductListService productService;

        public ProductBoxComponent(ProductListService _product){
            productService=_product;
            _product.listProduct.ForEach(x=>Console.WriteLine(x.Name));
        }

       public IViewComponentResult Invoke(Boolean sapxep=true){
            var _product=new List<Product>();
        if(sapxep){
            _product = productService.listProduct.OrderBy(x => x.Price).ToList();
        }else{
            _product = productService.listProduct.OrderByDescending(x => x.Price).ToList();

        }
            return View(_product);
       }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace RazorpageWebapp
{
    public class ProductListService
    {   
            
        public Product product {set;get;}
           public List<Product> listProduct{set; get;}= new List<Product>(){
            new Product {Id=1, Name="iphone", Description="ram 2 gb",Price=200000},
            new Product {Id=2, Name="samsung", Description="ram 5 gb",Price=505000},
            new Product {Id=3, Name="VIvo", Description="ram 2 gb",Price=904000}
        };
        public List<Product> getAllProducts()=>listProduct;
        public Product FindProduct(int id){
            var result= from p in listProduct where p.Id == id select p;
            return result.FirstOrDefault();
        }
    }
}

using EF1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text;

namespace EF1
{
    internal class Program
    {
        static void CreateDatabase()
        {

            using var dbcontext = new shopContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;

            var kq = dbcontext.Database.EnsureCreated();
            //EnsureCreatedAsync là phươnng thức của DatabaseFacade để tạo ra database,
            //nếu database nó đang không tồn tại, nếu DB đã tồn tại thì không làm gì cả.
            Console.WriteLine(kq);
            if (kq)
            {
                Console.WriteLine($"tao thanh cong {dbname}");

            }
            else
            {
                Console.WriteLine($"khong tao duoc {dbname}");

            }

            Console.WriteLine("hello");
        }
        static void DropeDatabase()
        {

            using var dbcontext = new shopContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;

            var kq = dbcontext.Database.EnsureDeleted();
            //EnsureCreatedAsync là phươnng thức của DatabaseFacade để tạo ra database,
            //nếu database nó đang không tồn tại, nếu DB đã tồn tại thì không làm gì cả. 
            Console.WriteLine(kq);
            if (kq)
            {
                Console.WriteLine($"Xoa thanh cong {dbname}");

            }
            else
            {
                Console.WriteLine($"k xoa duoc {dbname}");

            }

            Console.WriteLine("hello");
        }
        // Thực hiện chèn hai dòng dữ liệu vào bảng Product
        // Dùng AddAsync trong DbSet và trong DbContext
        static void InsertSampleData()
        {
            using var dbcontext = new shopContext();
            // Thêm 2 danh mục vào Category
            var cate1 = new Category() { Name = "Cate1", Description = "Description1" };
            var cate2 = new Category() { Name = "Cate2", Description = "Description2" };
            dbcontext.SaveChanges();

            // Thêm 5 sản phẩm vào Products
            dbcontext.AddRange(
                new Product() { Name = "Sản phẩm 1", Price = 12, Category = cate2 },
                new Product() { Name = "Sản phẩm 2", Price = 11, Category = cate2 },
                new Product() { Name = "Sản phẩm 3", Price = 33, Category = cate2 },
                new Product() { Name = "Sản phẩm 4(1)", Price = 323, Category = cate1 },
                new Product() { Name = "Sản phẩm 5(1)", Price = 333, Category = cate1 }

            );
            dbcontext.SaveChanges();
            // Các sản phầm chèn vào
            /*
            foreach (var item in products)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"ID: {item.ProductId}");
                stringBuilder.Append($"tên: {item.Name}");
                stringBuilder.Append($"Danh mục {item.CategoryId}({item.Category.Name})");
                Console.WriteLine(stringBuilder);
            }
            */
            // ID: 1tên: Sản phẩm 2Danh mục 2(Cate2)
            // ID: 2tên: Sản phẩm 1Danh mục 2(Cate2)
            // ID: 3tên: Sản phẩm 3Danh mục 2(Cate2)
            // ID: 4tên: Sản phẩm 4(1)Danh mục 1(Cate1)
            // ID: 5tên: Sản phẩm 5(1)Danh mục 1(Cate1)

        }


        static void DeleteProduct(int id, string newName)
        {
            using var dbcontext = new shopContext();
            // Linq
            var products = dbcontext.products.ToList();


            Product product1 = (from p in dbcontext.products
                                where p.ProductId == 2
                                select p
                              ).FirstOrDefault();// lấy ra kết quả đầu tiên của kq truy vấn

            if (product1 != null)
            {

                dbcontext.Remove(product1);
                dbcontext.SaveChanges();
                Console.WriteLine("xoa thanh cong");

            }
            else
            {
                Console.WriteLine(product1 == null ? "Kk xoa duoc" : product1);
            }


        }
        static void Main(string[] args)
        {


            /*
            using var dbcontext = new shopContext();

            var product=(from p in dbcontext.products where p.ProductId==3 select p).FirstOrDefault();

            var e= dbcontext.Entry(product);//tham chiếu Category
            e.Reference(p => p.Category).Load();

            Console.WriteLine(product);

            var category = (from p in dbcontext.categories where p.CategoryId == 2 select p).FirstOrDefault();
            var e2 = dbcontext.Entry(category);//tham chiếu Category
            e2.Collection(p => p.products).Load();
    
            Console.WriteLine($"có {category.products.Count()} san pham");
            */

            // DropeDatabase();
            // CreateDatabase();

            //InsertSampleData();
            //query=============================

            using var dbcontext = new shopContext();
            var products = dbcontext.products.Find(3);
            Console.WriteLine(products);
            //Products.Take(2).tolisst lấy 2 sp đầu tiên


            // DropeDatabase();
            //InsertProduct();
            //RenameProduct(1, "Con lon");
            //ReadProduct();


        }
    }
}

/*
public static void InsertProduct()
{
    using (var context = new shopContext())
    {
        // Thêm sản phẩm 1 AddRange add đưuọc mảng

        var products = new object[] {
                    new Product() { Name = "San pham 3", Provider = "CTY A" },
                     new Product() { Name = "San pham 4", Provider = "CTY 8" },
                     new Product() { Name = "San pham 5", Provider = "CTY C" },
                 };

        context.Add(new Product
        {
            Name = "Sản phẩm 1",
            Provider = "Công ty 1"
        });
        // Thêm sản phẩm 2
        context.Add(new Product
        {
            Name = "Sản phẩm 2",
            Provider = "Công ty 1"
        });

        // Thực hiện cập nhật thay đổi trong DbContext lên Server
        int rows = context.SaveChanges();
        Console.WriteLine($"Đã lưu {rows} sản phẩm");

    }
}
static void ReadProduct()
{
    using var dbcontext = new shopContext();
    // Linq
    var products = dbcontext.products.ToList();
    // products.ForEachlproduct TO product.PrintInfo()):
    var qr = from product in dbcontext.products
             where product.Provider.Contains("Công ty")
             orderby product.ProductId descending
             select product;

    qr.ToList().ForEach(product => Console.WriteLine(product));

    Product product1 = (from p in dbcontext.products
                        where p.ProductId == 2
                        select p
                      ).FirstOrDefault();// lấy ra kết quả đầu tiên của kq truy vấn
    Console.WriteLine(product1 == null ? "Khong co ket qua" : product1);

}
static void RenameProduct(int id, string newName)
{
    using var dbcontext = new shopContext();
    // Linq
    var products = dbcontext.products.ToList();


    Product product1 = (from p in dbcontext.products
                        where p.ProductId == 2
                        select p
                      ).FirstOrDefault();// lấy ra kết quả đầu tiên của kq truy vấn

    if (product1 != null)
    {

        
          ngắt theo dõi 
        EntityEntry<Product> eProduct = context.Entry(product);
        eProduct.State = EntityState.Detached;
        
        // dbcontext se theo dõi product1
        product1.Name = newName;
        dbcontext.SaveChanges();
    }
    else
    {
        Console.WriteLine(product1 == null ? "Khong co ket qua" : product1);
    }


}

*/
using System.Linq;
using System.Text;

namespace LINQ
{
    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }         // tên
        public double Price { set; get; }        // giá
        public string[] Colors { set; get; }     // các màu sắc
        public int Brand { set; get; }           // ID Nhãn hiệu, hãng
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }
        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        override public string ToString()
           => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

    }
    public class Brand
    {
        public string Name { set; get; }
        public int ID { set; get; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

           

            //Product p = new Product(1, "ABC", 100, new string[] { "xanh", "Do" }, 2);
            //Console.WriteLine(p.ToString());
            Console.OutputEncoding = Encoding.UTF8;
            var brands = new List<Brand>() {
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 2, Name = "Công ty BBB"},
                new Brand{ID = 4, Name = "Công ty CCC"},
            };

            var products = new List<Product>()
            {
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };


            // Lấy ra sp có giá là 400
            var query = from p in products where p.Price == 400 select p;//IEnumerable trả ra kiểu
            query.ToList().ForEach(p => Console.WriteLine(p));// đã tự động chuyển thành chuỗi
            //SELECT // như map()
            //var SelectNameP= products.Select(p=>p.Name );
            var SelectNameP = products.Select(p =>
            {
                return new
                {
                    Ten = p.Name,
                    Gia = p.Price
                };
            });
            var SelectNameP2 = products.SelectMany(p =>//lưu các tập hợp mảng thành chuỗi
            {
                return p.Colors;
            });

            SelectNameP.ToList().ForEach(p => Console.WriteLine(p));

            //WHERE
            var filterWhere = products.Where(x => x.Price > 400);
            filterWhere.ToList().ForEach(p => Console.WriteLine(p));

            //Min, Max, Sum,Average
            int[] numbers = { 1, 2, 3, 4, 5, 4, 3 };
            Console.WriteLine(numbers.Where(n => n % 2 == 0).Min());

            Console.WriteLine(products.Min(p => p.Price));

            //JOIN
            var joinProductBrand = products.Join(brands, p => p.Brand/*brandID*/, b => b.ID, (p, b) => new { Name = p.Name, ThuongHieu = b.Name });
            joinProductBrand.ToList().ForEach(p => Console.WriteLine(p));
            //Group Join
            var groupjoin = brands.GroupJoin(products, b => b.ID, p => p.Brand,
                (brand, product) =>
                {
                    return new
                    {
                        ThuongHieu = brand.Name,
                        CacSanPham = product
                    };
                });
            groupjoin.ToList().ForEach(p =>
            {
                Console.WriteLine(p.ThuongHieu);
                p.CacSanPham.ToList().ForEach(p => Console.WriteLine(p));
            });

            //Take
            products.Take(3);// Lấy 3 phần tử đầu tiên
            //Skip thì lấy sau phần tử thứ 3

            //Orderby /OrderByDescending
            products.OrderBy(p => p.Price);// Tăng dần về giá

            //Reverse
            //GroupBy
            var groupBy = products.GroupBy(p => p.Price);//nhóm giá(mỗi mức giá có nhiều sản phẩm)
            groupBy.ToList().ForEach(p =>
            {
                Console.WriteLine(p.Key);
                p.ToList().ForEach(p => Console.WriteLine(p));
            });

            //Distinct loại bỏ sp có cùng giá trị
            numbers.Distinct().ToList().ForEach(n => Console.WriteLine(n));
            //Single(nếu k tìm thấy thì lỗi) (SingleOrDefalt nếu k tìm thấy thì ra null)
            var single = products.Single(p => p.Price == 600);// nếu có 1 cái đúng thì lấy nó nếu nhiều cái đúng lỗi find()
            Console.WriteLine(single);
            //Any trả về true nếu có 1 cái thỏa mãn  //Giống Some()
            //All nếu tất cả thỏa mãn thì trả về true không thì false
            //Count đếm các sp có trong product hoặc đếm sp theo yêu cầu


            // In tên sp, tên thương hiệu có giá 300-400 giam dan
            var ketquabt = products.Join(brands, p => p.Brand, b => b.ID, (p, b) =>
            {
                return new
                {
                    Ten = p.Name,
                    TenThuongHieu = b.Name,
                    Gia = p.Price
                };

            }).Where(kq=>kq.Gia>200&&kq.Gia<400);
            ketquabt.ToList().ForEach(p => Console.WriteLine(p));


            /*cú pháp
           1) xác ddiunhj nguồn: from tenphantu in Enumerables
           2) Lay dữ liệu: select, group by...

           */
            // 1 Lấy ra tên các sản phẩm
            var bt1 = from p in products select p.Name;
            var bt11 = from p in products select $"{p.Name} : {p.Price}";// trả ra tên và giá
            var bt111 = from p in products select new { Ten = p.Name };// trả ra Đối tượng kiểu vô danh
            //2 lấy ra các sp có giá 400
            var bt2 = from p in products where p.Price == 400 select new { Gia = p.Price };
            // lấy ra sp có giá <=500 và màu xanh
            var bt22 = from p in products
                       from color in p.Colors// màu từ sản phẩm product
                       where p.Price == 400 && color == "Xanh"
                       orderby p.Price // descending lớn xuống nhỏ
                       select new { Gia = p.Price , Cacmau=p.Colors};//các màu là mảng
                                                                     // Chuyển mảng thành chuỗi   string.Join(",", numbers);

            // nhóm sản phẩm theo giá
            var ketqua = from product in products
                         where product.Price >= 400 && product.Price <= 500
                         group product by product.Price;
            foreach (var group in ketqua)
            {
                // Key là giá trị dùng để phân loại (nhóm): là giá
                Console.WriteLine(group.Key);
                foreach (var product in group)
                {
                    Console.WriteLine($"    {product.Name} - {product.Price}");
                }

            }
            // Dùng thêm biến vào LINQ, lưu kết quả của một biểu thức tính toán nào đó, thêm vào mệnh đề bằng cách viết let tenvien = biểu_thức, ví dụ với mỗi loại giá - có bao nhiêu sản phẩm
            var ketqua2 = from product in products                  // các sản phẩm trong products
                         group product by product.Price into gr    // nhóm thành gr theo giá(Lưu kết quả vào gr)
                         let count = gr.Count()                    // số phần tử trong nhóm
                         select new
                         {                              // trả về giá và số sản phầm có giá này
                             price = gr.Key,
                             number_product = count
                         };

            foreach (var item in ketqua2)
            {
                Console.WriteLine($"{item.price} - {item.number_product}");
            }

            //Ví dụ, truy vấn sản phẩm, mỗi sản phẩm căn cứ vào Brand ID của nó - lấy tên Brand tương ứng
            var ketqua3 = from product in products
                         join brand in brands on product.Brand equals brand.ID
                         select new
                         {
                             name = product.Name,
                             brand = brand.Name,
                             price = product.Price
                         };

            foreach (var item in ketqua3)
            {
                Console.WriteLine($"{item.name,10} {item.price,4} {item.brand,12}");
            }


            //Trong truy vấn trên, sản phẩm nào không tìm được thông tin brand ở ngồn bên phải
            //join thì sẽ bỏ qua. Giờ muốn, các sản phẩm kể cả không thấy brand cũng trả về
            //- có nghĩa nguồn bên trái lấy không phụ thuộc vào bên phải thì dùng kỹ thuật left join như sau:
            var ketqua4 = from product in products
                         join brand in brands on product.Brand equals brand.ID into t
                         from brand2 in t.DefaultIfEmpty() //brand2 là các products nếu k tìm thấy trong t thì = null
                          select new
                         {
                             name = product.Name,
                             brand = (brand2 == null) ? "NO-BRAND" : brand2.Name,
                             price = product.Price
                         };

            foreach (var item in ketqua4)
            {
                Console.WriteLine($"{item.name,10} {item.price,4} {item.brand,12}");
            }
        }
    }
}
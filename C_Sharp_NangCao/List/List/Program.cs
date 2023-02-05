// See https://aka.ms/new-console-template for more information
using List;
using System.Diagnostics;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");

List<int> ds1 =new List<int>() { 1,2};
ds1.Add(1);
ds1.AddRange(new int[] { 2, 3, 4 });
ds1.Insert(0, 10);// chèn vào vị trí 0
ds1.RemoveAt(0);//xóa vị trí 0
////ds1.RemoveAll();// xóa hết
//ds1.Clear();
//ds1.Remove(9);// xóa 1 phần tử đầu tiên gặp
ds1.ForEach((x) => Console.Write(x));
Console.WriteLine("hello");

var newList = ds1.FindAll(x => x >2); //Find chỉ tìm 1 phần tử
newList.ForEach((x) => Console.Write(x));
Console.WriteLine();


Console.WriteLine(ds1.Count);
List<Product> products =new List<Product>()
{
    new Product() {Name="iphone",Price=1000,Origin="china",ID=1},
    new Product() {Name="sasmung",Price=200,Origin="china",ID=2},
    new Product() {Name="iphone",Price=300,Origin="china",ID=3},
    new Product() {Name="iphone",Price=600,Origin="china",ID=4},
};

products.Sort((p1, p2) =>
{
    if (p1.Price == p2.Price) return 0;
    if (p1.Price < p2.Price) return -1;
    return 1;
});
products.ForEach(x =>
{
    Console.WriteLine($"{x.Name} {x.Price}");
});


//SortedList có các key
SortedList<string, Product> product2 = new SortedList<string, Product>();
product2["sp1"] = new Product() { Name = "iphone", Price = 600, Origin = "china", ID = 4 };
product2["sp1"] = new Product() { Name = "nokia", Price = 600, Origin = "china", ID = 4 };
product2.Add("sp3", new Product() { Name = "hehe", Price = 600, Origin = "china", ID = 4 });
//Có thể lấy đc sản phẩm có key
var p1 = product2["sp1"];
var keys = product2.Keys;
var values = product2.Values;
//lấy dc các value từ product2 hoặc keys
values.ToList().ForEach(x => Console.WriteLine($"{x.Name} {x.Price}"));
//cách 2
foreach(KeyValuePair<string,Product> item in product2)
{
    Console.WriteLine($"{item.Key} {item.Value.Name}");
}

//Remove("sp1");
//RemoveAt("0");
//Clear();
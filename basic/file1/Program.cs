// See https://aka.ms/new-console-template for more information
using file1;
Console.Beep();
int a = 20;
Console.ForegroundColor = ConsoleColor.Red;
Console.Title = "Bài học đầu tiên";
Console.ResetColor();
float b;
string sinput;
sinput = Console.ReadLine();
b = float.Parse(sinput);
Console.WriteLine($"hello {a}");
Console.WriteLine("hello {0}", b);

string[] ds = new string[3] { "", "trường", "" };
ds[0] = "trung";
Array.Sort(ds);
foreach (string s in ds)
{
    Console.WriteLine(s);
}


Class1 class1 = new Class1(2, 3);
Console.WriteLine(class1.Tong(2, 3));
//xinchao(ref a);

//void xinchao( ref int thamso) // tham chiếu giống con trỏ
//{
//    console.writeline("hello");
//}

// sử dụng generic: giúp tối ưu code không phải viết lại nhiều lần khi giải thuật login giống nhau
// /tự động nhận biết kiểu dữ liệu; queue,list sử dụng kiểu này
void Swap<T>(ref T x, ref T y)
{
    T t;
    t = x;
    x = y;
    y = t;
}
//Swap<int>(ref a, ref b);// sẽ bắt buộc là int nếu k truyền int thì nó tự nhận biết

// Anonymous - kiểu dữ liệu vô danh
// object - thuộc tính - chỉ đọc
var sanpham = new
{
    Ten = "iphone",
    nam = "2012"
};
List<Class1> convat = new List<Class1>() { new Class1() { Height = 20, Width = 30},
new Class1() { Height = 10, Width = 30},
new Class1() { Height = 100, Width = 30}};
//truy van Linq
var ketqua = from sv in convat
             where sv.Height > 50 && sv.Width>0
             select new
             {
                 chieucao = sv.Height,
                 beo = sv.Width
             };
foreach (var s in ketqua)
{
    Console.WriteLine(s);
}
//Dynamic - kiểu dữ liệu động
dynamic tenbien1;
//null nullable: biên tham trị có khả năng nhận giá trị null
int? age=null;

//delegate (type) biến = phương thữc

int[] arr = { 1, 2, 3, 4 };
int[] arr2 = arr;
arr2[1] = 1000;
arr.ToList().ForEach(x => Console.WriteLine(x));
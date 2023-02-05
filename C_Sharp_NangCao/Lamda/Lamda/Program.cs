// See https://aka.ms/new-console-template for more information


Action<string> thongbao = (string s) => Console.WriteLine(s);
thongbao("hello");
thongbao?.Invoke("xin chao");

Action thongbao2 = () => Console.WriteLine("xin chao cac ban");
thongbao2();

Action<string, string> thongbao3 = (s, name) => Console.WriteLine(s + " " + name);
thongbao3("chao", "Trung");

Func<int, int, int> tinhtoan = (a, b) =>
{
    return a + b;
};
Console.WriteLine(tinhtoan(2, 3));

//sử dụng lamda trong 1 so thư viện của .net
int[] mang = { 1, 2, 3, 4, 5, 6, 7 };
var kq = mang.Select((int x) => { return x*x; });// giống như map trả về mảng mới 
Console.WriteLine("\n binh phuong cac so trong mang la:");
foreach (var k in kq)
{
    Console.Write(k+ " ");
}

var kq2 = mang.Where(x =>
{
    return x % 4 == 0; // return ra phần tử có kết quả là true như filter trong javascrip
});
Console.WriteLine("\n cac phan tu chia het cho 4 trong mang la:");
foreach (var k in kq2)
{
    Console.Write(k + " ");
}
;

Console.WriteLine("\n cac so chan trong mang la:");
mang.ToList().ForEach((x) =>
{
    if (x % 2 == 0)
    {
        Console.Write(x);
    }
});


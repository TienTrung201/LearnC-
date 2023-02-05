


internal class Program
{
    delegate void ShowLog(string message);
    static public void Info(string s)
    {

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(string.Format("Info: {0}", s));
        Console.ResetColor();
    }
    static public void Warning(string s)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(string.Format("Waring: {0}", s));
        Console.ResetColor();
    }
    static int Sum(int x, int y)
    {
        return x + y;
    }
    public static void TestFunc(int x, int y)
    {
        Func<int, int, int> tinhtong;         // biến tinhtong phù hợp với các hàm trả về kiểu int, có 2 tham số kiểu int
        tinhtong = Sum;                     // Hàm Sum phù hợp nên có thể gán cho biến

        var ketqua = tinhtong(x, y);
        Console.WriteLine(ketqua);
    }
    static void Tong(int a, int b, ShowLog log)
    {
        int kq = a + b;
        log?.Invoke($"Tong la {kq}");
        //log($"Tong la {kq}");

    }
    static void Main(string[] args)
    {
        ShowLog showLog;

        showLog = Info;         // showLog gán bằng phương thức Info
        showLog("Thông báo");   // Thi hành delegate chính là thi hành Info

        showLog = Warning;      // showLog gán bằng phương thức Warning
        showLog("Thông báo");   // Thi hành delegate chính là thi hành Info

        showLog += Warning;         // Nối thêm Warning vào delegate
        showLog += Info;            // Nối thêm Info vào delegate
        showLog += Warning;         // Nối thêm Warning vào delegate

        //Một lần gọi thi hành tất cả các phương thức trong chuỗi delegate
        showLog("TestLog");         //Hoặc an toàn: showLog?.Invoke("TestLog");


        //Action
        Action<string> ShowLog = null;// không cần khai báo thuần Action hỗ trợ  
        //Action không có kiểu trả về
        ShowLog += Info;
        ShowLog("hello Action");
        //FUNC
        Func<int, int , int> tinhtoan;//bool là kiểu trả về còn lại là tham số
        int a = 5, b = 5;
        tinhtoan = Sum;
        Console.WriteLine($"Kêt quả là{tinhtoan(a,b)}");
    

        //delegate với callback
        Tong(4, 5, Info);
    }
}

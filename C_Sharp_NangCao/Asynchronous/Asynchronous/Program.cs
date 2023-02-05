using System.Net;

namespace Asynchronous
{
    internal class Program
    {
        public static string DownloadWebpage(string url, bool showresult)
        {
            using (var client = new WebClient())
            {
                Console.Write("Starting download ...");
                string content = client.DownloadString(url);
                Thread.Sleep(3000);
                if (showresult)
                    Console.WriteLine(content.Substring(0, 150));

                return content;
            }
        }

        public static void TestDownloadWebpage()
        {
            string url = "https://code.visualstudio.com/";
            DownloadWebpage(url, true);
            Console.WriteLine("Do somthing ...");
        }
        static void DoSomeThing(int n, string name, ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"start {name}");

                Console.ResetColor();
            }
            for (int i = 0; i < n; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"hello {name} lan thu {i}");
                    Console.ResetColor();
                }

                Thread.Sleep(1000);
            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"end {name}");
                Console.ResetColor();
            }
       
            //nếu k sử dụng lock thì nó sẽ bị loạn khi chạy bất đồng bộ cái này nhảy sang cái kia hiểu sai

        }

        static async Task Task1()
        {
           Task t1 = new Task(() =>
            {
                DoSomeThing(8, "T1", ConsoleColor.Blue);

            }); 
            t1.Start();
            await t1;
            //t1.Wait();
            Console.WriteLine("t1 da hoan thanh khi await hoàn thành");
           // return t1; có await thì k cần trả lại nó sẽ cho phép chạy trên luồng mới mà k phải đợi như Wait() va tự động trả về 
        }
        static Task Task2()
        {
            Task t2 = new Task((ob) =>
            {
                string tnetacvu = (string)ob;
                DoSomeThing(5, tnetacvu, ConsoleColor.Red);

            }, "T2");
            t2.Start();// nếu start 2 lần thì báo lỗi

            t2.Wait();
            Console.WriteLine("t2 da hoan thanh");
            return t2;
        }
        static async Task Main(string[] args) // có thể biến hàm main thành bất đồng bộ

        {

            Task t1 = Task1();
            Task t2 = Task2();


            DoSomeThing(4, "T3", ConsoleColor.Green);

            //t2.Wait();
            await t1;
            await t2;
            //Task.WaitAll();// chờ hết mới chạy tiếp
           
            Console.WriteLine("End all");
            Console.ReadKey();
        }
    }
}
namespace phuongthucmorong
{
    static class Abc
    {
        public static void Print(this string s, ConsoleColor color)// mở rộng cho lớp nào thì tham số đầu tiên là đối tượng lớp đó
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            string s = "hello tientrung";
            s.Print(ConsoleColor.Yellow);

            int binh(int x) => x * x;
            binh(2);
            $"ninh phuong 2 cua {2} la: {binh(2)}".Print(ConsoleColor.Yellow);
        }
    }
}
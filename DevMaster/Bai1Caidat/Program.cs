// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
DateTime dbo2= DateTime.Now;
Console.WriteLine(dbo2+"xin chào mọi người");// tại sao lại bị lỗi
// tạo cho tao biến name age gender và in nó
// tạo cho tao đối tượng datetime và in ra nó
 

string name = "John"; 
int age = 25; 
string gender = "Male"; 
Console.WriteLine($"{name} xin chào");
Console.WriteLine("Name: {0}, Age: {1}, Gender: {2}", name, age, gender);
//giúp tao chuyển string sang int bằng nhiều cách
//nhập ngày sinh từ bàn phím và tin ra nó
Employee emp = new Employee();

        // emp.InputEmployeeInfo();
        // emp.DisplayEmployeeInfo();

 int n = 10;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                Console.Write(" ");
            }
            for (int k = 0; k <= i; k++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
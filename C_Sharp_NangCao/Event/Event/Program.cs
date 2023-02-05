namespace Event
{
    internal class Program
    {
        public delegate void SuKienNhapSo(int x);

        class UserInput
        {
            public event SuKienNhapSo sukiennhapso; //event cho phep nhan nhieu su kien delegate chỉ được += hoặc -= không dc gán

            public void Input()
            {
                do
                {
                    Console.Write("Nhap vao so nguyen: ");
                    string s =Console.ReadLine();
                    int i = int.Parse(s);

                    //Khi sukiennhapso đc đăng ký sự kiện thì mới thực thi
                    sukiennhapso?.Invoke(i);
                }while(true);
            }
        }
        class BinhPhuong
        {
            public void Sub(UserInput input)
            {
                input.sukiennhapso += Binh;
            }
            public void Binh(int x)
            {
                Console.WriteLine($"Bình phương cua {x} là {x*x}");
            }
        };
        class Can2
        {
            public void Sub(UserInput input)
            {
                input.sukiennhapso += Can;
            }
            public void Can(int x)
            {
                Console.WriteLine($"Can bac 2 cua {x} là {Math.Sqrt(x)}");
            }
        };
        static void Main(string[] args)
        {
            //publisher
            UserInput input = new UserInput();

            //subcriber
            //đăng kí sự kiện với biểu thức Lamda
            input.sukiennhapso += x =>
            {
                Console.WriteLine($"ban vua nhap so {x}");
            };

            BinhPhuong tinh = new BinhPhuong();
            Can2 tinhcan= new Can2();

            tinhcan.Sub(input);
            tinh.Sub(input);
            input.Input();
        }
    }
}
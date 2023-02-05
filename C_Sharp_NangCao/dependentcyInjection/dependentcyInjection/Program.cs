using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static dependentcyInjection.Car;
using Microsoft.Extensions.Configuration;


using Microsoft.Extensions.Configuration.Json;
namespace dependentcyInjection
{
    interface IClassB
    {
        public void ActionB();
    }
    interface IClassC
    {
        public void ActionC();
    }

    class ClassC : IClassC
    {
        public ClassC() => Console.WriteLine("ClassC is created");
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB : IClassB
    {
        IClassC c_dependency;
        public ClassB(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }
    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created");
        public void ActionC()
        {
            Console.WriteLine("Action in C1");
        }
    }

    class ClassB1 : IClassB
    {
        IClassC c_dependency;
        public ClassB1(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB1 is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in B1");
            c_dependency.ActionC();
        }
    }

    class ClassB2 : IClassB
    {

        IClassC c_dependency;
        string message;
        public ClassB2(IClassC classc, string mgs)
        {
            c_dependency = classc;
            message = mgs;
            Console.WriteLine("ClassB2 is created");
        }
        public void ActionB()
        {
            Console.WriteLine(message);
            c_dependency.ActionC();
        }
    }




    class ClassA
    {
        IClassB b_dependency;
        public ClassA(IClassB classb)
        {
            b_dependency = classb;
            Console.WriteLine("ClassA is created");
        }
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }




    public class Horn
    {
        int lever = 0;//do lon
        public Horn(int lever) => this.lever = lever;

        public void Beep() => Console.WriteLine("Beep - beep - beep ...");
    }

    public class Car
    {
        Horn horn { set; get; }
        // Inject bằng phương thức khởi tạo (cho nên ta phải làm như này)
        public Car(Horn _horn) => horn = _horn;
        public void Beep()
        {

            // chức năng Beep xây dựng cố định với Horn


            //Horn horn = new Horn(8);//khi horn thay phương thức khởi tạo ta lại phải viết lại class đó


            // tự tạo đối tượng horn (new) và dùng nó

            horn.Beep();
        }
    }

    internal class Program
    {
        public static ClassB2 CreateB2Factory(IServiceProvider serviceprovider)
        {
            var service_c = serviceprovider.GetService<IClassC>();
            var sv = new ClassB2(service_c, "Thực hiện trong ClassB2");
            return sv;
        }

        public class MyServiceOptions// đây là đói tượng chứa các dữ liệu của đối tượng Myservice
        {
            public string data1 { get; set; }
            public int data2 { get; set; }
        }

        public class MyService
        {
            public string data1 { get; set; }
            public int data2 { get; set; }

            // Tham số khởi tạo là IOptions, các tham số khởi tạo khác nếu có khai báo như bình thường
            public MyService(IOptions<MyServiceOptions> options)
            {
                // Đọc được MyServiceOptions từ IOptions
                MyServiceOptions opts = options.Value;
                data1 = opts.data1;
                data2 = opts.data2;
            }
            public void PrintData() => Console.WriteLine($"{data1} / {data2}");
        }
        static void Main(string[] args)
        {
            /*IClassC objectC = new ClassC1();
            IClassB objectB = new ClassB1(objectC);
            ClassA objectA = new ClassA(objectB);

            objectA.ActionA();*/

            // Inject bằng phương thức khởi tạo
            Horn horn = new Horn(7);// nếu phương thức khởi tạo thay đổi chỉ cần thay đổi ở đây
            Car car = new Car(horn);
            // Inject bằng phương thức khởi tạo 
            car.Beep();


            /*========================================
        // thư viện dependentcy Ịnection

        //DI Continer : ServiceCollection


        //- Đăng ký các dịch vụ (lớp)
        // -Servitprovider->   get Service  cho phép lấy ra các dịch vụ đã đăng kí ở service Collection
        var services = new ServiceCollection();
        //đăng ký dịch vụ...
        //IclassC, classc,classc1


        //Singleton  chỉ tạo ra 1 đối tượng nếu nối tượng đã được tạo ra thì nó không tạo mới đối tượng nữa 
        //Singleton          tendichvu,Kiểudichvudctaora
        //services.AddSingleton<IClassC, ClassC>();

        //transient mỗi lần truy cập lấy ra dịch vụ thì một đối tượng mới sẽ được tạo ra
        //services.AddTransient<IClassC, ClassC>();

        //scoped trong mỗi phạm vi chỉ có 1 đối tượg được tạo ra

        services.AddScoped<IClassC, ClassC>();

        var provider = services.BuildServiceProvider();

        //var classc=provider.GetService<ClassC>();
        for(int i = 0; i < 2; i++)
        {
            IClassC c =provider.GetService<IClassC>();
            Console.WriteLine(c.GetHashCode());// mỗi đối tượng có một mã hashCode 
        }

        using (var scope=provider.CreateScope())// có nghĩa là scope chỉ dc tạo trong khối lệnh này
        {
            var provider1 = services.BuildServiceProvider();
            for (int i = 0; i < 2; i++)
            {
                IClassC c = provider1.GetService<IClassC>();
                Console.WriteLine(c.GetHashCode());// mỗi đối tượng có một mã hashCode 
            }
        }
        */
            /*
                        var services = new ServiceCollection();

                        services.AddSingleton<ClassA, ClassA>();
                        /*========k dùng Factory
                        services.AddSingleton<IClassB>((IServiceProvider serviceprovider) => {
                            var service_c = serviceprovider.GetService<IClassC>();
                            var sv = new ClassB2(service_c, "thuc hien trong ClassB2");
                            return sv;
                        });
                        ***
                        services.AddSingleton<IClassB>(CreateB2Factory);//Lúc này có thể sử dụng Factory trên để đăng ký IClassB.
                        services.AddSingleton<IClassC, ClassC>();

                        var provider = services.BuildServiceProvider();

                        ClassA a = provider.GetService<ClassA>();
                        a.ActionA();

                        */


            //Option


            IConfigurationRoot configurationroot;
            ConfigurationBuilder configBuilder2 = new ConfigurationBuilder();
            configBuilder2.SetBasePath(Directory.GetCurrentDirectory());     // file config ở thư mục hiện tại
            configBuilder2.AddJsonFile("cauhinh.json");                  // nạp config định dạng JSON
            configurationroot = configBuilder2.Build();

            var key1 = configurationroot.GetSection("section1").GetSection("data1").Value;
            Console.WriteLine(key1);

            var sectionMyServiceOptions = configurationroot.GetSection("MyServiceOptions");
            var services = new ServiceCollection();
            services.AddSingleton<MyService>();
            /*Sử dụng factory
            var opts = Options.Create(new MyServiceOptions()
            {
                data1 = "DATA-DATA-DATA-DATA-DATA",
                data2 = 12345
            });
            MyService myService = new MyService(opts);
            myService.PrintData();
            *///Sử dụng factory

            services.Configure<MyServiceOptions>(
               sectionMyServiceOptions
            );

            var provider = services.BuildServiceProvider();
            var myservice = provider.GetService<MyService>();
            myservice.PrintData();



        }


    }

}
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace typeAttributeC
{
    internal class Program
    {


        /*
            MOta
                -Thông tin chi tiet
         */

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
        // cho phép get gì thì truyeend cái đấy vào
        class MotaAttribute : Attribute
        {
            public string Thongtinchitiet { get; set; }

            public MotaAttribute(string _Thongtinchitiet)
            {
                Thongtinchitiet = _Thongtinchitiet;
            }
        }
        [Mota("Lop chua thong tin ve user")]
        class User
        {
            [Mota("mota ten nguoi dung")]
            [Required(ErrorMessage = "Name phai thiet lap")]
            [StringLength(58, MinimumLength = 3, ErrorMessage = "Ten phai dai tu 3 den 100 ky tu")]

            public string Name { get; set; }
            [Mota("mota Email nguoi dung")]
            //[Range(18, 80, ErrorMessage = "tuổi phai tu 18-80")]

            [EmailAddress(ErrorMessage = "Địa chi email sai cau truc")]
            public string Email { get; set; }
            [Phone]
            public string phoneNumber { get; set; }
            [Obsolete("Phuong thuc nay da noi thoi k nen su dung nua, ca thay the boi showinfo")]
            public void PrintInfo() => Console.WriteLine(Name);
        }
        static void Main(string[] args)
        {
            int a = 1;
            int[] b = { 1, 2, 3 };
            Type t1 = typeof(int);
            var t2 = typeof(string);
            var t3 = typeof(Array);
            var t = a.GetType();
            var t4 = b.GetType();
            Console.WriteLine(t.FullName);
            Console.WriteLine(t4.FullName);

            Console.WriteLine("Ten cac thuoc tinh");
            t4.GetProperties().ToList().ForEach(p => Console.WriteLine(p.Name));


            Console.WriteLine("Ten cac phuong thuc ma no co");
            t4.GetMethods().ToList().ForEach(p => Console.WriteLine(p.Name));
            // còn rất nhiều


            User user = new User() { Name = "XT", Email = "tientrung14122012@gmail.com" ,phoneNumber="0336237176"};
            // cách lấy thuộc tính và giá trị của đối tượng
            var properties = user.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                string name = property.Name;
                var value = property.GetValue(user);
                Console.WriteLine($"{name}: {value}");
            }

            //user.PrintInfo();///////////////////////

            var properties2 = user.GetType().GetProperties();

            foreach (PropertyInfo property in properties2)
            {
                foreach (var attr in property.GetCustomAttributes(false))// nó có thể có nhiều mô tả nên dùng lặp
                {
                    MotaAttribute mota = attr as MotaAttribute; // convert sang kiểu motaattribute
                    if (mota != null)// nếu có mô tả chạy
                    {
                        var value = property.GetValue(user);
                        var name = property.Name;
                        Console.WriteLine($"({name}) - {mota.Thongtinchitiet}: {value}");
                    }

                }

            }


            // kiểm tra attribute 
            Console.WriteLine("kiểm tra validate: ");
            ValidationContext context = new ValidationContext(user);
            var result = new List<ValidationResult>();
            bool kq = Validator.TryValidateObject(user, context, result, true);
            if (kq == false)
            {
                result.ToList().ForEach(er =>
                {
                    Console.WriteLine(er.MemberNames.First());
                    Console.WriteLine(er.ErrorMessage);
                });


            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file1
{
    partial class Class1 //(partial) có thể viết 2 file riêng biệt và tổng hợp phương thức thuộc tính có namespace, class giống nhau

    {
        private int height;
        private int width;

        public Class1(int height, int width)
        {
            Height = height;
            Width = width;
        }
        public Class1()
        {
      
        }

        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }

        /// <summary>
        /// Phương thức này trả về tổng hai số nguyên
        /// </summary>
        /// <param name="a">Số nguyên 1</param>
        /// <param name="b">Số nguyên 2</param>
        /// <returns>Tổng a+b</returns>
        public int Tong(int a, int b)
        {
            return a + b;
        }

    }

}

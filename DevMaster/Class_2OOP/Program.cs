// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Tính trừu tượng (abstraction) mô tả một cách tổng quát hóa (tập trung vào thông tin cần thiết)
// mà không chi tiết thông tin về các đối tượng, không gắn cứng với một đối tượng cụ thể cần mô tả 
//(triển khai với interface, abstract)

// Tính đóng gói (encapsulation) dữ liệu đối tượng cố gắng như nằm trong một hộp đen,
// các thành phần khác bên ngoài đối tượng không trực tiếp tác động đến dữ liệu 
//(bên ngoài truy cập, tác động thông qua các phương thức public cho phép, qua setter, getter ...)

// Tính đa hình (polymorphism) đối tượng ứng xử khác nhau tùy trường hợp cụ thể

// Tính kế thừa (inheritance) đặc tính của lớp được kế thừa từ một lớp khác

// var hcn= new HinhChuNhat(2,3);
// hcn.ChieuDai=3;
// Console.WriteLine(hcn.Dientich);

var emp1= new Employee("trung", new DateTime(2001,12,12),"Male",20000);
Console.WriteLine("Nhan vien"+emp1);
emp1.DisplayUse();

var button= new Button();
var button2=new Button(){top=10,left=20,color="red"};
button.top=10;
button.left=10;
button.color="greens";
button2.DrawWindow();
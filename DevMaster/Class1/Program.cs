// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var Employee =new List<Employee>(){
    new Employee {Id="hello", Name="John",dob=new DateTime(1999,12,12),BasicSalary=20000,SalaryLevel=2},
    new Employee {Id="hello", Name="trung",dob=new DateTime(1999,12,12),BasicSalary=20000,SalaryLevel=1},
    new Employee {Id="hello", Name="Hiển",dob=new DateTime(1999,12,12),BasicSalary=3000,SalaryLevel=4},
};
var Employee2 =new List<Employee>(){
    new Employee ("hello", "John",new DateTime(1999,12,12),20000,2),
    new Employee ("hello", "trung",new DateTime(1999,12,12),20000,1),
    new Employee ("hello", "Hiển",new DateTime(1999,12,12),3000,4),
};
Employee2.ToList().ForEach(p=>Console.WriteLine(p));


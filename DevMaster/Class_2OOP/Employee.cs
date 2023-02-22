public class Employee:Person
{
    public decimal Salary { get; set; }
    public Employee(string _Name, DateTime _dob, string _Gender, decimal _Salary) :base(_Name, _dob, _Gender){
        Salary = _Salary;
    }
    public override void DisplayUse(){
        Console.WriteLine($"{Name} {Gender} {Salary}");

    }
    public void Work(){
        Console.WriteLine("Lam viec");
    }
}
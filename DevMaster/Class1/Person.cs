class Employee
{

    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime dob { get; set; }
    public int SalaryLevel { get; set; }
    public int BasicSalary { get; set; }
    public Employee(string Id, string Name, DateTime dob, int SalaryLevel, int BasicSalary)
    {
        this.Id = Id; this.Name = Name;
        this.dob = dob; this.SalaryLevel = SalaryLevel;
        this.BasicSalary = BasicSalary;
    }
    public Employee(){
        
    }
    public int CalculateAge => DateTime.Now.Year - dob.Year;

    public int getIncome => BasicSalary * SalaryLevel;
    override public string ToString() => $"name: {Name},Lương nhân viên: {getIncome}, Tuổi: {CalculateAge}";
}

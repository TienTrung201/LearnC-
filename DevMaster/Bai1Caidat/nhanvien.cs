class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public void DisplayEmployeeInfo()
    {
        Console.WriteLine("Employee Information");
        Console.WriteLine("Employee ID: " + EmployeeId);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Date of Birth: " + DateOfBirth.ToShortDateString());
        Console.WriteLine("Address: " + Address);
        Console.WriteLine("Phone Number: " + PhoneNumber);
        Console.WriteLine("Email: " + Email);
    }
      public void InputEmployeeInfo()
    {
        Console.WriteLine("Enter Employee Information");
        Console.Write("Employee ID: ");
        EmployeeId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Name: ");
        Name = Console.ReadLine();
        Console.Write("Date of Birth (MM/DD/YYYY): ");
        DateOfBirth = Convert.ToDateTime(Console.ReadLine());
        Console.Write("Address: ");
        Address = Console.ReadLine();
        Console.Write("Phone Number: ");
        PhoneNumber = Console.ReadLine();
        Console.Write("Email: ");
        Email = Console.ReadLine();
    }
}


public class Person
{
    public string Name { get; set; }
    public DateTime dob { get; set; }
    public string Gender { get; set; }

    public virtual void DisplayUse(){
        Console.WriteLine($"{Name} {Gender}");
    }

    public Person(string _Name, DateTime _dob, string _Gender) 
    {
        Name=_Name;Gender=_Gender;dob=_dob;
    }
    public override string ToString()
    {
        return $"{Name} {Gender}";
    }
}
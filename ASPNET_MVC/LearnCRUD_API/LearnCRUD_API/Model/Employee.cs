using System.ComponentModel.DataAnnotations;

namespace LearnCRUD_API.Model
{
	public class Employee
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		[MaxLength(51,ErrorMessage ="name không quá 50 ký tự")]
		public string Name { get; set; }
		public List<Employee> Employees { get; set;}
	}
}

using Microsoft.EntityFrameworkCore;

namespace LearnCRUD_API.Model
{
	public class EmployeeContext:DbContext
	{
		public EmployeeContext(DbContextOptions<EmployeeContext>options) : base(options) { }
		public DbSet<Employee> Employees { get; set;} 
	}
}

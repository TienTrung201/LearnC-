using LearnCRUD_API.Model;

namespace LearnCRUD_API.EmployeeData
{
	public class SqlEmployeeData : IEmployeeData
	{
		public EmployeeContext _enoloyeeContext;
		public SqlEmployeeData(EmployeeContext employeeContext)
		{
			_enoloyeeContext = employeeContext;
		}
		public Employee AddEmployee(Employee employee)
		{
			employee.Id= Guid.NewGuid();
			_enoloyeeContext.Employees.Add(employee);
			_enoloyeeContext.SaveChanges();
			return employee;
		}

		public void DeleteEmployee(Employee employee)
		{
			_enoloyeeContext.Employees.Remove(employee);
			_enoloyeeContext.SaveChanges();

		}

		public Employee EditEmployee(Employee employee)
		{
			var existingEmployee = _enoloyeeContext.Employees.Find(employee.Id);
			if(existingEmployee != null)
			{
				existingEmployee.Name=employee.Name;
				_enoloyeeContext.Employees.Update(existingEmployee);
				_enoloyeeContext.SaveChanges();
			}

			return employee;
		}

		public Employee GetEmployee(Guid id)
		{
			return _enoloyeeContext.Employees.FirstOrDefault(e => e.Id == id);
		}

		public List<Employee> GetEmployees() 
		{
			return _enoloyeeContext.Employees.ToList();
		}
	}
}

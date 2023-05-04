using LearnCRUD_API.Model;

namespace LearnCRUD_API.EmployeeData
{
	public class MockEmployeeDada : IEmployeeData
	{
		private List<Employee> employees=new List<Employee>()
		{
			new Employee()
			{
				Id=Guid.NewGuid(),
				Name="trung"
			},
			new Employee()
			{
				Id=Guid.NewGuid(),
				Name="Phuc"
			},
		};
		public Employee AddEmployee(Employee employee)
		{
			employee.Id= Guid.NewGuid();
			employees.Add(employee);
			return employee;
		}

		public void DeleteEmployee(Employee employee)
		{
			employees.Remove(employee);
		}

		public Employee EditEmployee(Employee employee)
		{
			var existingEmployee= GetEmployee(employee.Id);
			existingEmployee.Name= employee.Name;
			return existingEmployee;
		}

		public Employee GetEmployee(Guid id)
		{
			return employees.FirstOrDefault(e=>e.Id==id);
		}

		public List<Employee> GetEmployees()
		{
			return employees;
		}
	}
}

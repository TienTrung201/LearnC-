using LearnCRUD_API.EmployeeData;
using LearnCRUD_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnCRUD_API.Controllers
{

	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private IEmployeeData _employeeData;
		public EmployeesController(IEmployeeData employeeData)
		{
			_employeeData = employeeData;
		}
		[HttpGet]
		[Route("api/[controller]")]
		public IActionResult GetEmployees()
		{
			return Ok(_employeeData.GetEmployees());

		}
		[HttpGet]
		[Route("api/[controller]/{id}")]
		public IActionResult GetEmployee(Guid id)
		{
			var emplppyee = _employeeData.GetEmployee(id);
			if (emplppyee != null)
			{
				return Ok(emplppyee);
			}
			return NotFound();
		}
		[HttpPost]
		[Route("api/[controller]")]
		public IActionResult GetEmployee(Employee employee)
		{
			_employeeData.AddEmployee(employee);
			return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
		}

		[HttpPatch]
		[Route("api/[controller]/{id}")]
		public IActionResult EditEmployee(Guid id, Employee employee)
		{
			var existingEmployee = _employeeData.GetEmployee(id);
			if (existingEmployee != null)
			{
				employee.Id = existingEmployee.Id;
				_employeeData.EditEmployee(employee);
			}
			return Ok(employee);

		}
		[HttpDelete]
		[Route("api/[controller]/{id}")]
		public IActionResult DeleteEmployee(Guid id)
		{
			var employee = _employeeData.GetEmployee(id);
			if (employee != null)
			{
				_employeeData.DeleteEmployee(employee);
				return Ok(employee);
			}
			return NotFound();

		}
	}

}

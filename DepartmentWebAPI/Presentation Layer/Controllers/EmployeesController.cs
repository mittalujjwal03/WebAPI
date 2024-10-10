// Controllers/EmployeesController.cs
using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmployees()
    {
        var employees = _employeeRepository.GetAllEmployees();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> GetEmployee(int id)
    {
        var employee = _employeeRepository.GetEmployeeById(id);
        if (employee == null) return NotFound();
        return Ok(employee);
    }

    [HttpPost]
    public ActionResult<Employee> PostEmployee(Employee employee)
    {
        _employeeRepository.AddEmployee(employee);
        return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
    }

    [HttpPut("{id}")]
    public IActionResult PutEmployee(int id, Employee employee)
    {
        if (id != employee.EmployeeId) return BadRequest();
        _employeeRepository.UpdateEmployee(employee);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        _employeeRepository.DeleteEmployee(id);
        return NoContent();
    }
}

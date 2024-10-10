// Controllers/DepartmentsController.cs
using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentsController(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Department>> GetDepartments()
    {
        var departments = _departmentRepository.GetAllDepartments();
        return Ok(departments);
    }

    [HttpGet("{id}")]
    public ActionResult<Department> GetDepartment(int id)
    {
        var department = _departmentRepository.GetDepartmentById(id);
        if (department == null) return NotFound();
        return Ok(department);
    }

    [HttpPost]
    public ActionResult<Department> PostDepartment(Department department)
    {
        _departmentRepository.AddDepartment(department);
        return CreatedAtAction(nameof(GetDepartment), new { id = department.DepartmentId }, department);
    }

    [HttpPut("{id}")]
    public IActionResult PutDepartment(int id, Department department)
    {
        if (id != department.DepartmentId) return BadRequest();
        _departmentRepository.UpdateDepartment(department);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDepartment(int id)
    {
        _departmentRepository.DeleteDepartment(id);
        return NoContent();
    }
}

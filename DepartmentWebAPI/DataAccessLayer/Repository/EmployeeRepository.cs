using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Employee> GetAllEmployees()
    {
        return _context.Employees.Include(e => e.DepartmentName).ToList();
    }

    public Employee GetEmployeeById(int id)
    {
        return _context.Employees.Include(e => e.DepartmentName)
            .FirstOrDefault(e => e.EmployeeId == id);
    }

    public void AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public void UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
        _context.SaveChanges();
    }

    public void DeleteEmployee(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}
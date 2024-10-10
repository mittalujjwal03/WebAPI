using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int id);
    }
}

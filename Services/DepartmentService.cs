using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentService()
        {
            _departmentService = new DepartmentService();
        }
        public void CreateDepartment(Department department)=> _departmentService.CreateDepartment(department);


        public List<Department> GetDepartment()=>_departmentService.GetDepartment();


        public void UpdateDepartment(Department department)=> _departmentService.UpdateDepartment(department);
        public Department? GetDepartmentByCode(string Code) => _departmentService.GetDepartmentByCode(Code);
    }
}

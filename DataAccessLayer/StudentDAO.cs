using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StudentDAO
    {
        public List<Student> GetStudent()
        {
            List<Student> students = new List<Student>();
            CourseManagementDbContext context = new CourseManagementDbContext();
            students = context.Students.ToList();
            return students;
        }
    }
}

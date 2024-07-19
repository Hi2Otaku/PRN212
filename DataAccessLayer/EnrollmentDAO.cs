using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EnrollmentDAO
    {
        public static List<Enrollment> getEnrollment()
        {
            CourseManagementDbContext db = new CourseManagementDbContext();
            var enrollments = db.Enrollments
                .Include(enr => enr.Course)
                .Include(enr => enr.Student)
                .Include(enr => enr.Semester)
                .ToList();
            return enrollments;
        }
    }
}

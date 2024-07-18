using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EnrollmentDAO
    {
        private readonly CourseManagementDbContext _context;

        public EnrollmentDAO(CourseManagementDbContext context)
        {
            _context = context;
        }

        public List<Enrollment> GetAllEnrollments()
        {
            return _context.Enrollments.ToList();
        }

        public Enrollment GetEnrollmentById(int id)
        {
            return _context.Enrollments.Find(id);
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
        }

        public void DeleteEnrollment(int id)
        {
            var enrollment = _context.Enrollments.Find(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                _context.SaveChanges();
            }
        }
    }
}


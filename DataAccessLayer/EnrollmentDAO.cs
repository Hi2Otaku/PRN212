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

        public static void addEnrollment(int studentId, int courseId, int semesterId)
        {
            CourseManagementDbContext db = new CourseManagementDbContext();
            var enrollments = db.Enrollments.ToList();
            Enrollment enrollment = new Enrollment();
            enrollment.CourseId = courseId;
            enrollment.StudentId = studentId;
            enrollment.SemesterId = semesterId;
            enrollment.EnrollmentId = enrollments.Count + 1;
            db.Enrollments.Add(enrollment);
            db.SaveChanges();

            var assessments = db.Assessments
                .Where(ass => ass.CourseId == courseId)
                .ToList();

            foreach (var ass in assessments)
            {
                Mark mark = new Mark();
                mark.AssessmentId = ass.Id;
                mark.EnrollmentId = enrollment.EnrollmentId;
                MarksDAO.addMark(mark);
            }

            db.SaveChanges();

        }
    }
}

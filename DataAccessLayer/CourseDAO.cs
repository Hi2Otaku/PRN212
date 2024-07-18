using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CourseDAO
    {
        private static List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();
            CourseManagementDbContext db = new CourseManagementDbContext();
            courses = db.Courses.ToList();
            return courses;
        }

        private static void DeleteCourse(Course course)
        {
            CourseManagementDbContext db = new CourseManagementDbContext();
            db.Courses.Remove(course);
        }

        private static void UpdateCourse(Course course)
        {
            CourseManagementDbContext db = new CourseManagementDbContext();
            db.Courses.Update(course);
        }

        private static void CreateCourse(Course course)
        {
            CourseManagementDbContext db = new CourseManagementDbContext();
            db.Courses.Add(course);
        }

        private static Course? GetCourseById(int id)
        {
            Course? course = new Course();
            CourseManagementDbContext db = new CourseManagementDbContext();
            course = db.Courses.Find(id);
            return course;
        }
    }
}

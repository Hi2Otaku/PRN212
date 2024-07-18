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
        private readonly CourseManagementDbContext _context;

        public CourseDAO(CourseManagementDbContext context)
        {
            _context = context;
        }

        public List<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges(); 
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges(); 
        }

        public void CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges(); 
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.Find(id);
        }
    }
}

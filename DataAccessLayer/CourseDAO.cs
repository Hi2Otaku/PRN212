using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CourseDAO
    {
        public static List<Course> GetCourses()
        {
            CourseManagementDbContext _context = new CourseManagementDbContext();
            return _context.Courses.ToList();
        }

        public static void DeleteCourse(Course course)
        {
<<<<<<< HEAD
            var existingCourse = _context.Courses.Find(course.Id);
            if (existingCourse != null)
            {
                _context.Courses.Remove(existingCourse);
                _context.SaveChanges();
            }
=======
            CourseManagementDbContext _context = new CourseManagementDbContext();
            _context.Courses.Remove(course);
            _context.SaveChanges(); 
>>>>>>> d27ef21b766e89704dfec946bef1eb2ad0da1ff2
        }

        public static void UpdateCourse(Course course)
        {
            CourseManagementDbContext _context = new CourseManagementDbContext();
            _context.Courses.Update(course);
            _context.SaveChanges(); 
        }

<<<<<<< HEAD
        public void CreateCourse(Course NewCourse)
        {
            NewCourse.Id = GetNextCourseId();
            _context.Courses.Add(NewCourse);
=======
        public static void CreateCourse(Course course)
        {
            CourseManagementDbContext _context = new CourseManagementDbContext();
            _context.Courses.Add(course);
>>>>>>> d27ef21b766e89704dfec946bef1eb2ad0da1ff2
            _context.SaveChanges(); 
        }
        public static List<int> GetCredits()
        {
            CourseManagementDbContext _context = new CourseManagementDbContext();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT DISTINCT Credits FROM Courses";
                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var credits = new List<int>();
                    while (result.Read())
                    {
                        credits.Add(Convert.ToInt32(result.GetValue(0)));
                    }
                    return credits;
                }
            }
        }
        public static Course GetCourseById(int id)
        {
            CourseManagementDbContext _context = new CourseManagementDbContext();
            return _context.Courses.Find(id);
        }
        private int GetNextCourseId()
        {
            return _context.Courses.Any() ? _context.Courses.Max(c => c.Id) + 1 : 1;
        }
    }
}

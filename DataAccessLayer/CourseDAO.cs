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
            var existingCourse = _context.Courses.Find(course.Id);
            if (existingCourse != null)
            {
                _context.Courses.Remove(existingCourse);
                _context.SaveChanges();
            }
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges(); 
        }

        public void CreateCourse(Course NewCourse)
        {
            NewCourse.Id = GetNextCourseId();
            _context.Courses.Add(NewCourse);
            _context.SaveChanges(); 
        }
        public List<int> GetCredits()
        {
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
        public Course GetCourseById(int id)
        {
            return _context.Courses.Find(id);
        }
        private int GetNextCourseId()
        {
            return _context.Courses.Any() ? _context.Courses.Max(c => c.Id) + 1 : 1;
        }
    }
}

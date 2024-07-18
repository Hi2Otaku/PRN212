using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AssessmentDAO
    {
        private readonly CourseManagementDbContext _context;

        public AssessmentDAO(CourseManagementDbContext context)
        {
            _context = context;
        }

        public List<Assessment> GetAllAssessments()
        {
            return _context.Assessments.ToList();
        }

        public Assessment GetAssessmentById(int id)
        {
            return _context.Assessments.Find(id);
        }

        public void AddAssessment(Assessment assessment)
        {
            _context.Assessments.Add(assessment);
            _context.SaveChanges();
        }

        public void UpdateAssessment(Assessment assessment)
        {
            _context.Assessments.Update(assessment);
            _context.SaveChanges();
        }

        public void DeleteAssessment(int id)
        {
            var assessment = _context.Assessments.Find(id);
            if (assessment != null)
            {
                _context.Assessments.Remove(assessment);
                _context.SaveChanges();
            }
        }
    }
}

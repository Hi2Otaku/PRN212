using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AssessmentsDAO
    {

        private static List<Assessment> GetAssessment()
        {
            List<Assessment> assessments = new List<Assessment>();
            CourseManagementDbContext db = new CourseManagementDbContext();
            assessments = db.Assessments.ToList();
            return assessments;
        }

        private static void DeleteAssessment(Assessment assessment)
        {
            CourseManagementDbContext db = new CourseManagementDbContext();
            db.Assessments.Remove(assessment);
        }

        private static void UpdateAssessment(Assessment assessment)
        {
            CourseManagementDbContext db = new CourseManagementDbContext();
            db.Assessments.Update(assessment);
        }

        private static void CreateAssessment(Assessment assessment)
        {
            CourseManagementDbContext db = new CourseManagementDbContext();
            db.Assessments.Add(assessment);
        }

        private static Assessment? GetAssessmentsById(int id)
        {
            Assessment? assessment = new Assessment();
            CourseManagementDbContext db = new CourseManagementDbContext();
            assessment = db.Assessments.Find(id);
            return assessment;
        }
    }
}

using BusinessObjects;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SemestersDAO
    {
        public List<Semester> Load_Semester(string code, int year, DateOnly startDate, DateOnly endDate)
        {
            List<Semester> semesters = new List<Semester>();
            try
            {
                using (var _dbcontext = new CourseManagementDbContext())
                {
                    IQueryable<Semester> query = _dbcontext.Semesters;
                    if (!code.IsNullOrEmpty()) { query = query.Where(s => s.Code == code); }
                    if (year != -1) { query = query.Where(s => s.Year == year); }
                    if( startDate != null) { query = query.Where(s => s.BeginDate == startDate); }
                    if(endDate != null) { query = query.Where(s => s.EndDate == endDate); }
                    semesters = query.ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return semesters;
        }
    }
}

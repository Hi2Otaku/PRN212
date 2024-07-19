using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository enrollmentRepository;
        public EnrollmentService()
        {
            enrollmentRepository = new EnrollmentRepository();
        }
        public List<Enrollment> getEnrollment()
        {
            return enrollmentRepository.getEnrollment();
        }
    }
}

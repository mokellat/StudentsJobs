using StudentsJobs.Models;
using System;

namespace StudentsJobs.Services
{
    public class ApplicationService
    {
        private readonly StudentJobContext _dbContext;

        public ApplicationService(StudentJobContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Application> GetApplicationsForStudent(int studentId)
        {
            return _dbContext.Applications.Where(a => a.StudentId == studentId);
        }

        public bool ApplyForJob(int studentId, int jobPostingId)
        {
            // check if the student has already applied for the job posting
            var existingApplication = _dbContext.Applications.FirstOrDefault(a => a.StudentId == studentId && a.JobPostingId == jobPostingId);
            if (existingApplication != null)
            {
                return false; // application already exists
            }

            // create a new application
            var application = new Application
            {
                StudentId = studentId,
                JobPostingId = jobPostingId,
                Status = "open",
                DateApplied = DateTime.UtcNow
            };

            _dbContext.Applications.Add(application);
            _dbContext.SaveChanges();

            return true;
        }

        public bool CancelApplication(int studentId, int applicationId)
        {
            var application = _dbContext.Applications.FirstOrDefault(a => a.ApplicationId == applicationId && a.StudentId == studentId);
            if (application == null)
            {
                return false; // application not found
            }

            _dbContext.Applications.Remove(application);
            _dbContext.SaveChanges();

            return true;
        }
    }
}

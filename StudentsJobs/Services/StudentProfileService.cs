using StudentsJobs.Models;
using StudentsJobs.Models.OTD_MODELS;
using System.Linq;

namespace StudentsJobs.Services
{
    public class StudentProfileService
    {
        private readonly StudentJobContext _dbContext;

        public StudentProfileService(StudentJobContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student GetProfile(int studentId)
        {
            return _dbContext.Students.FirstOrDefault(p => p.StudentId == studentId);
        }

        public void UpdateProfile(int studentId, StudentProfile profile)
        {
            var existingProfile = _dbContext.Students.FirstOrDefault(p => p.StudentId == studentId);

            if (existingProfile != null)
            {
                existingProfile.FirstName = profile.FirstName;
                existingProfile.LastName = profile.LastName;
                existingProfile.Email = profile.Email;
                existingProfile.PhoneNumber = profile.PhoneNumber;
                existingProfile.School = profile.School;
                existingProfile.Major = profile.Major;
                existingProfile.Skills = profile.Skills;
            }
            else
            {
                profile.StudentId = studentId;
                //_dbContext.Students.Add(profile);
            }

            _dbContext.SaveChanges();
        }
    }
}

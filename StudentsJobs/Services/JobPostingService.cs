using StudentsJobs.Models;
using StudentsJobs.Models.OTD_MODELS;
using System;

namespace StudentsJobs.Services
{
    public class JobPostingService
    {
        private readonly StudentJobContext _context;

        public JobPostingService(StudentJobContext context)
        {
            _context = context;
        }

        public List<JobPosting> GetJobPostings()
        {
            return _context.JobPostings.ToList();
        }

        public JobPosting GetJobPosting(int id)
        {
            return _context.JobPostings.FirstOrDefault(j => j.JobPostingId == id);
        }

        public JobPosting CreateJobPosting(JobPostingDTO jobPostingDto)
        {
            var jobPosting = new JobPosting
            {
                EmployerId = jobPostingDto.EmplyerId,
                Title = jobPostingDto.Title,
                Description = jobPostingDto.Description,
                Requirements = jobPostingDto.Requirements,
                ApplicationInstructions = jobPostingDto.ApplicationInstructions,
                Deadline = jobPostingDto.Deadline,
                DatePosted = DateTime.Now
            };
            _context.JobPostings.Add(jobPosting);
            _context.SaveChanges();

            //jobPostingDto.Id = jobPosting.JobposId;
            //jobPostingDto.DatePosted = jobPosting.DatePosted;

            return jobPosting;
        }

        public JobPosting UpdateJobPosting(JobPostingDTO jobPosting, int id)
        {
            var existingJobPosting = _context.JobPostings.FirstOrDefault(j => j.JobPostingId == jobPosting.Id);

            if (existingJobPosting == null)
            {
                return null;
            }

            existingJobPosting.Title = jobPosting.Title;
            existingJobPosting.Description = jobPosting.Description;
            existingJobPosting.Requirements = jobPosting.Requirements;
            existingJobPosting.ApplicationInstructions = jobPosting.ApplicationInstructions;
            existingJobPosting.Deadline = jobPosting.Deadline;

            _context.SaveChanges();

            return existingJobPosting;
        }

        public JobPosting DeleteJobPosting(int id)
        {
            var jobPostingToDelete = _context.JobPostings.FirstOrDefault(j => j.JobPostingId == id);

            if (jobPostingToDelete == null)
            {
                return null;

            }
            _context.JobPostings.Remove(jobPostingToDelete);
            _context.SaveChanges();

            return jobPostingToDelete;
        }

        public bool JobPostingExists(int id)
        {
            return _context.JobPostings.Any(j => j.JobPostingId == id);
        }
    }
}
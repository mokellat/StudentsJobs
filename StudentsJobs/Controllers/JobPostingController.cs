using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsJobs.Models;
using StudentsJobs.Models.OTD_MODELS;
using StudentsJobs.Services;

namespace StudentsJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostingController : ControllerBase
    {
        private readonly JobPostingService _jobPostingService;

        public JobPostingController(JobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        [HttpGet]
        public IActionResult GetJobPostings()
        {
            var jobPostings = _jobPostingService.GetJobPostings();
            return Ok(jobPostings);
        }

        [HttpGet("{id}")]
        public IActionResult GetJobPosting(int id)
        {
            var jobPosting = _jobPostingService.GetJobPosting(id);

            if (jobPosting == null)
            {
                return NotFound();
            }

            return Ok(jobPosting);
        }

        [HttpPost]
        //[Authorize(Roles = "employer")]
        public IActionResult CreateJobPosting(JobPostingDTO jobPosting)
        {
            var createdJobPosting = _jobPostingService.CreateJobPosting(jobPosting);
            if (createdJobPosting == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetJobPosting), new { id = createdJobPosting.JobPostingId }, createdJobPosting);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "employer")]
        public IActionResult UpdateJobPosting(int id, JobPostingDTO jobPosting)
        {
            if (id != jobPosting.Id)
            {
                return BadRequest();
            }

            var updatedJobPosting = _jobPostingService.UpdateJobPosting(jobPosting, id);

            if (updatedJobPosting == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "employer")]
        public IActionResult DeleteJobPosting(int id)
        {
            var deletedJobPosting = _jobPostingService.DeleteJobPosting(id);

            if (deletedJobPosting == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

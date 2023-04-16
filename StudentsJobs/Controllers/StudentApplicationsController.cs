using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsJobs.Services;

namespace StudentsJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApplicationsController : ControllerBase
    {

        private readonly ApplicationService _applicationService;

        public StudentApplicationsController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult GetApplications(int studentId)
        {
            var applications = _applicationService.GetApplicationsForStudent(studentId);
            return Ok(applications);
        }

        [HttpPost("{jobPostingId}")]
        public IActionResult ApplyForJob(int studentId, int jobPostingId)
        {
            var success = _applicationService.ApplyForJob(studentId, jobPostingId);
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Application could not be created.");
            }
        }

        [HttpDelete("{applicationId}")]
        public IActionResult CancelApplication(int studentId, int applicationId)
        {
            var success = _applicationService.CancelApplication(studentId, applicationId);
            if (success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

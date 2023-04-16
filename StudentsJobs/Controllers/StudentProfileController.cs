using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StudentsJobs.Services;
using StudentsJobs.Models;
using StudentsJobs.Models.OTD_MODELS;

namespace StudentsJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "student")]
    public class StudentProfileController : ControllerBase
    {
        private readonly StudentProfileService _profileService;

        public StudentProfileController(StudentProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public IActionResult GetProfile(int studentId)
        {
            var profile = _profileService.GetProfile(studentId);

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        [HttpPut]
        public IActionResult UpdateProfile(int studentId, StudentProfile profile)
        {
            if (studentId != profile.StudentId)
            {
                return BadRequest();
            }

            _profileService.UpdateProfile(studentId, profile);

            return NoContent();
        }
    }
}

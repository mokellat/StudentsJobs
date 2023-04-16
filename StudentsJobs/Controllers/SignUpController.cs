using Microsoft.AspNetCore.Mvc;
using StudentsJobs.Library.Utility;
using StudentsJobs.Services;
using StudentsJobs.Models;
using StudentsJobs.Controllers.Utility;

namespace StudentsJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignUpController : BaseApiController
    {
        private readonly SignUpService _service;

        public SignUpController(SignUpService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult SignUp([FromBody] SignUpRequest request)
        {
            var result = _service.SignUpUser(request);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Invalid role");
            }
        }
    }
}

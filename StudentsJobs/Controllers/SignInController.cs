using Microsoft.AspNetCore.Mvc;
using StudentsJobs.Controllers.Utility;
using StudentsJobs.Models;
using StudentsJobs.Services;

namespace StudentsJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignInController : BaseApiController
    {
        private readonly SignInService _signInService;

        public SignInController(SignInService signInService)
        {
            _signInService = signInService;
        }

        [HttpPost]
        public IActionResult SignIn(SignInRequest request)
        {
            var user = _signInService.SignIn(request.Username, request.Password);

            if (user == null)
            {
                return Unauthorized(); // Invalid credentials
            }

            var response = new SignInResponse
            {
                UserId = user.UserId,
                AuthToken = user.AuthToken
            };

            return Ok(response);
        }

        public class SignInRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class SignInResponse
        {
            public int UserId { get; set; }
            public string AuthToken { get; set; }
        }
    }
}

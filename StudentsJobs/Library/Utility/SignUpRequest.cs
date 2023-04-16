namespace StudentsJobs.Library.Utility
{
    public class SignUpRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string School { get; set; }
        public int? GraduationYear { get; set; }
        public string Major { get; set; }
        public double? GPA { get; set; }
        public string Skills { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
        public string Industry { get; set; }
        public int? CompanySize { get; set; }
        public string Description { get; set; }
    }
}

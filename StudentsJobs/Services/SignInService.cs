using StudentsJobs.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StudentsJobs.Models.OTD_MODELS;

namespace StudentsJobs.Services
{
    public class SignInService
    {
        private readonly StudentJobContext _dbContext;

        public SignInService(StudentJobContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User SignIn(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return null; // User not found
            }

            var hashedPassword = HashPassword(password);

            if (user.PasswordHash != hashedPassword)
            {
                return null; // Invalid password
            }

            // Generate new authentication token
            user.AuthToken = GenerateAuthToken();
            _dbContext.SaveChanges();

            return user;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private string GenerateAuthToken()
        {
            // Generate 64-character random string
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[32];
                rng.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}

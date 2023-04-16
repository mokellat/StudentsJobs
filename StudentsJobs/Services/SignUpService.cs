using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using StudentsJobs.Library.Utility;
using StudentsJobs.Models;
using Microsoft.EntityFrameworkCore;
using iRely.Common;
using StudentsJobs.Models.OTD_MODELS;

namespace StudentsJobs.Services
{

    public class SignUpService
    {
        private readonly StudentJobContext _dbContext;

        public SignUpService(StudentJobContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsUsernameTaken(string username)
        {
            return _dbContext.Users.Any(u => u.Username == username);
        }

        public bool IsEmailTaken(string email)
        {
            return _dbContext.Students.Any(s => s.Email == email) || _dbContext.Employers.Any(e => e.CompanyEmail == email);
        }

        public bool SignUpUser(SignUpRequest request)
        {

            // Create new user record
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var user = new User
                    {
                        Username = request.Username,
                        PasswordHash = HashPassword(request.Password),
                        AuthToken = null // auth token is generated upon successful login
                    };

                    if (user == null)
                    {
                        return false;
                    }
                    else
                    {
                        _dbContext.Users.Add(user);
                        _dbContext.SaveChanges();
                        transaction.Commit();
                    }

                    // Create new student or employer record
                    if (request.Role == "student")
                    {
                        var student = new Student
                        {
                            StudentId = user.UserId,
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            Email = request.Email,
                            PhoneNumber = request.PhoneNumber,
                            School = request.School,
                            Major = request.Major,
                            Skills = request.Skills,
                            Cv = null // CV is uploaded as a separate file
                        };
                        _dbContext.Students.Add(student);
                    }
                    else if (request.Role == "employer")
                    {
                        var employer = new Employer
                        {
                            EmployerId = user.UserId,
                            CompanyName = request.CompanyName,
                            CompanyEmail = request.Email,
                            PhoneNumber = request.PhoneNumber,
                            CompanyWebsite = request.CompanyWebsite,
                            Industry = request.Industry,
                            CompanySize = request.CompanySize,
                            Description = request.Description
                        };
                        _dbContext.Employers.Add(employer);
                    }
                    else
                    {
                        // Invalid role
                        return false;
                    }

                    _dbContext.SaveChanges();
                    //transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }

                return true;
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}

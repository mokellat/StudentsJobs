using System;
using System.Collections.Generic;

namespace StudentsJobs.Models.OTD_MODELS;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? AuthToken { get; set; }

    public virtual Employer? Employer { get; set; }

    public virtual Student? Student { get; set; }
}

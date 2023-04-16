using System;
using System.Collections.Generic;

namespace StudentsJobs.Models.OTD_MODELS;

public partial class SignUp
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int UserId { get; set; }

    public virtual Employer User { get; set; } = null!;

    public virtual Student UserNavigation { get; set; } = null!;
}

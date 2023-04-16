using System;
using System.Collections.Generic;
using StudentsJobs.Models.OTD_MODELS;

namespace StudentsJobs.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? School { get; set; }

    public string? Major { get; set; }

    public string? Skills { get; set; }

    public byte[]? Cv { get; set; }

    public virtual ICollection<Application> Applications { get; } = new List<Application>();

    public virtual User StudentNavigation { get; set; } = null!;
}

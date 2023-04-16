using System;
using System.Collections.Generic;
using StudentsJobs.Models.OTD_MODELS;

namespace StudentsJobs.Models;

public partial class Employer
{
    public int EmployerId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyEmail { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? CompanyWebsite { get; set; }

    public string? Industry { get; set; }

    public int? CompanySize { get; set; }

    public string? Description { get; set; }

    public virtual User EmployerNavigation { get; set; } = null!;

    public virtual ICollection<JobPosting> JobPostings { get; } = new List<JobPosting>();
}

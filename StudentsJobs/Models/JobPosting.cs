using System;
using System.Collections.Generic;

namespace StudentsJobs.Models;

public partial class JobPosting
{
    public int JobPostingId { get; set; }

    public int EmployerId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Requirements { get; set; }

    public string? ApplicationInstructions { get; set; }

    public DateTime? Deadline { get; set; }

    public DateTime DatePosted { get; set; }

    public virtual ICollection<Application> Applications { get; } = new List<Application>();

    public virtual Employer Employer { get; set; } = null!;
}

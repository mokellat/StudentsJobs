using System;
using System.Collections.Generic;

namespace StudentsJobs.Models;

public partial class Application
{
    public int ApplicationId { get; set; }

    public int JobPostingId { get; set; }

    public int StudentId { get; set; }

    public DateTime DateApplied { get; set; }

    public string Status { get; set; } = null!;

    public virtual JobPosting JobPosting { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}

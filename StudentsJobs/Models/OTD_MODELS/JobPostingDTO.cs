namespace StudentsJobs.Models.OTD_MODELS
{
    public class JobPostingDTO
    {

        public int Id { get; set; }
        public int EmplyerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string ApplicationInstructions { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime DatePosted { get; set; }
            //public EmployerDTO Employer { get; set; }
    }
}

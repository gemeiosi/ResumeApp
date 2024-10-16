using System.ComponentModel.DataAnnotations;

namespace ResumeApp.Data.Dtos
{
    public class CandidateDto
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Degree { get; set; }
        public string?  CV { get; set; }
        public DateTime? CreationTime { get; set; }
    }
}

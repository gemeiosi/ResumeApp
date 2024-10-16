using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResumeApp.Data.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Degree { get; set; }
        public string?  CV { get; set; }
        public DateTime? CreationTime { get; set; } = DateTime.Now;
    }
}

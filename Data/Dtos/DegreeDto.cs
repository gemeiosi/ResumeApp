using System.ComponentModel.DataAnnotations;

namespace ResumeApp.Data.Dtos
{
    public class DegreeDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? CreationTime { get; set; } = DateTime.Now;
    }
}

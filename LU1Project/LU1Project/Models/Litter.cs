using System.ComponentModel.DataAnnotations;

namespace LU1Project.Models
{
    public class Litter
    {
        [Key] // Data Annotation
        public int Id { get; set; }

        [Required] // Data Annotation
        public string? Location { get; set; }

        public string? Description { get; set; }

        public DateTime ReportDate { get; set; }

        public string? Color { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Course_Registration_API.Models
{
    public class Course
    {
        public int Id { get; set; }
        
        [RegularExpression(@"^[A-Z]{3}\d{3}$")]
        public required string CourseCode { get; set; }
        [Required] public required string CourseTitle { get; set; }
        [Required] public required string LecturerName { get; set; }
    }
}

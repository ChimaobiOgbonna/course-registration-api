using Microsoft.EntityFrameworkCore;

namespace Course_Registration_API.Models
{
    [Index(nameof(StudentId), nameof(CourseId), IsUnique = true)]
    

    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

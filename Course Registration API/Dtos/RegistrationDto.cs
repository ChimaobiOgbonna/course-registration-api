namespace Course_Registration_API.Dtos
{
    public class RegistrationDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
    }
}

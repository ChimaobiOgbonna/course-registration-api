namespace Course_Registration_API.Dtos
{
    public class UpdateStudentDto
    {
            public string? RegNo { get; set; }
            public string? Name { get; set; }
            public string? Department { get; set; }
            public DateOnly? DateRegistered { get; set; }
        
    }
}

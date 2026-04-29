using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Course_Registration_API.Models
{
    [Index(nameof(RegNo), IsUnique = true)]

    public class Student
    {
        public int Id { get; set; }

        [Required] public required string RegNo { get; set; }
        [Required] public required string Name { get; set; }
        [Required] public required string Department { get; set; }
        public DateOnly DateRegistered { get; set; }
    }
}



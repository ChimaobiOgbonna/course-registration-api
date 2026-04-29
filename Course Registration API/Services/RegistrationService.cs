using Course_Registration_API.Data;
using Course_Registration_API.Dtos;
using Course_Registration_API.Models;
using Microsoft.EntityFrameworkCore;



namespace Course_Registration_API.Services
{
  
    public class RegistrationService
    {
        private readonly AppDbContext _context;

        public RegistrationService(AppDbContext context)
        {
            _context = context;
        }
        // Get all registrations
        public List<RegistrationDto> GetAll()
        {
            return _context.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .Select(sc => new RegistrationDto
                {
                    StudentId = sc.StudentId,
                    StudentName = sc.Student.Name,
                    CourseId = sc.CourseId,
                    CourseTitle = sc.Course.CourseTitle
                })
                .ToList();
        }

        // Register a student for a course
        public StudentCourse Register(int studentId, int courseId)
        {
            // Check if student exists
            
            var student = _context.Students.FirstOrDefault(s => s.Id == studentId)?? 
                throw new Exception("Student not found");

            // Check if course exists
            var course = _context.Courses.FirstOrDefault(s => s.Id == courseId) ??
                throw new Exception("Course not found");

            // Check if already registered
            var alreadyRegistered = _context.StudentCourses
                .Any(sc => sc.StudentId == studentId && sc.CourseId == courseId);

            if (alreadyRegistered)
            {
                throw new Exception("Student already registered for this course");
            }

            // Create registration

            var registration = new StudentCourse
                {
                     StudentId = studentId,
                     CourseId = courseId,
                     Student = student,
                     Course = course
                };

                _context.StudentCourses.Add(registration);
                _context.SaveChanges();

                return registration;
        }

        // Get registered courses for a student
        public List<Course> GetCoursesForStudent(int studentId)
        {
            return _context.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .Select(sc => sc.Course)
                .ToList();
        }


        //  Get students in a course
        public List<Student> GetStudentsInCourse(int courseId)
        {
            return _context.StudentCourses
                .Where(sc => sc.CourseId == courseId)
                .Select(sc => sc.Student)
                .ToList();
        }

        // Remove a student from a course
        public void Unregister(int studentId, int courseId)
        {
            var registration = _context.StudentCourses
                .FirstOrDefault(sc => sc.StudentId == studentId && sc.CourseId == courseId)
                ?? throw new Exception("Registration not found");

            _context.StudentCourses.Remove(registration);
        }
    }
}

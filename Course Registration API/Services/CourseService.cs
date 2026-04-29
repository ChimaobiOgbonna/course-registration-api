using Course_Registration_API.Data;
using Course_Registration_API.Dtos;
using Course_Registration_API.Models;


namespace Course_Registration_API.Services
{
    public class CourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }
        // Get all courses
        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }



        // Get a course by Id
        public Course? GetById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }


        // Add a new course
        public void Add(Course course)
        {
            // Optional: prevent duplicate CourseCode
            var exists = _context.Courses.Any(c => c.CourseCode == course.CourseCode);

            if (exists)
            {
                throw new Exception("Course with this code already exists");
            }

            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        // Update a course
        public void Update(int id, UpdateCourseDto updatedCourse)
        {
            var course = GetById(id) ?? throw new Exception("Course not found");

            course.CourseCode = updatedCourse.CourseCode ?? course.CourseCode;
            course.CourseTitle = updatedCourse.CourseTitle ?? course.CourseTitle;
            course.LecturerName = updatedCourse.LecturerName ?? course.LecturerName;

            _context.SaveChanges();
        }

        // Delete a course
        public void Delete(int id)
        {

            var course = GetById(id) ?? throw new Exception("Course not found");
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }





    }
}



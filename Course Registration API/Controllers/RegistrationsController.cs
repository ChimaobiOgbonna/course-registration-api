using Course_Registration_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Registration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly RegistrationService _registrationService;

        public RegistrationsController(RegistrationService registrationService)
        {
            _registrationService = registrationService;
        }


        //Post /api/Registrations?studentId={studentId}&courseId={courseId}
        [HttpPost] //POST /api/Registrations
        public IActionResult Register(int studentId, int courseId)
        {
            try
            {
                var result = _registrationService.Register(studentId, courseId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet] //GET /api/Registrations
        public IActionResult GetAll()
        {
            var registrations = _registrationService.GetAll();
            return Ok(registrations);
        }


        //GET /api/Registrations/student/{studentId}
        [HttpGet("student/{studentId}")] // to get registered courses for one student 
        public IActionResult GetCoursesForStudent(int studentId)
        {
            var courses = _registrationService.GetCoursesForStudent(studentId);
            return Ok(courses);
        }



        // GET /api/Registrations/course/{courseId}
        [HttpGet("course/{courseId}")] // to get registered students for one course
        public IActionResult GetStudentsInCourse(int courseId)
        {
            var students = _registrationService.GetStudentsInCourse(courseId);
            return Ok(students);
        }



        //DELETE /api/Registrations?studentId={studentId}&courseId={courseId}
        [HttpDelete] //delete student's registratio to a course
        public IActionResult Unregister(int studentId, int courseId)
        {
            try
            {
                _registrationService.Unregister(studentId, courseId);
                return Ok("Student removed from course");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

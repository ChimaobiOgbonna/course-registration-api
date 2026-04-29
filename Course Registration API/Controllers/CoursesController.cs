using Course_Registration_API.Dtos;
using Course_Registration_API.Models;
using Course_Registration_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Registration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CoursesController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet] //get the list all courses
        public IActionResult GetCourses()
        {
            var courses = _courseService.GetAll();
            return Ok(courses);
        }
        
        [HttpGet("{id}")] // get a course by id
        public IActionResult GetCourse(int id)
        {
            var course = _courseService.GetById(id);

            if (course == null)
            {
                return NotFound("Course not found");
            }

            return Ok(course);
        }

        [HttpPost] //add a new course
        public IActionResult AddCourse([FromBody] Course course)
        {
            try
            {
                _courseService.Add(course);

                return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPatch("{id}")] // udpdate a course record
        public IActionResult UpdateCourse(int id, [FromBody] UpdateCourseDto dto)
        {
            try
            {
                _courseService.Update(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")] // delete a course
        public IActionResult DeleteCourse(int id)
        {
            var course = _courseService.GetById(id);

            if (course == null)
            {
                return NotFound("Course not found");
            }

            _courseService.Delete(id);

            return Ok("Course deleted successfully");
        }

    }
}

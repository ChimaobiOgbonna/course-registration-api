using Course_Registration_API.Dtos;
using Course_Registration_API.Models;
using Course_Registration_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Registration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentsController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet] //get the list all student
        public IActionResult GetStudents()
        {
            var students = _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")] // get a student by id
        public IActionResult GetStudent(int id)
        {
            var student = _studentService.GetById(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        public StudentService Get_studentService1()
        {
            return _studentService;
        }

        [HttpPost] // add a new student
        public IActionResult AddStudent([FromBody] Student student)
        {
            try
            {
                _studentService.AddStudent(student);

                return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPatch("{id}")] // udpdate student records
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentDto dto)
        {
            try
            {
                _studentService.Update(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")] // delete a student
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentService.GetById(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            _studentService.Delete(id);

            return Ok("Student deleted successfully");
        }
    }
}

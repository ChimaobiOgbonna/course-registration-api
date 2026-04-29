using Course_Registration_API.Data;
using Course_Registration_API.Dtos;
using Course_Registration_API.Models;
using Course_Registration_API.Services;
using Microsoft.EntityFrameworkCore;


namespace Course_Registration_API.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        // Get all students
        public List<Student> GetAll()
        {
            return _context.Students.ToList(); // you can also write: return [.. _context.Students];
        }



        // Get a student by Id
        public Student? GetById(int id)
        {
            return _context.Students.FirstOrDefault(c => c.Id == id);
        }

        // Add a new student
        public void AddStudent(Student student)
        {
            var exists = _context.Students.Any(c => c.RegNo == student.RegNo);

            if (exists)
            {
                throw new Exception("Student with this RegNo already exists");
            }

            _context.Students.Add(student);
            _context.SaveChanges();
        }

        // Update a Student
        public void Update(int id, UpdateStudentDto updatedStudent)
        {
            var student = GetById(id) ?? throw new Exception("Student not found");

            student.RegNo = updatedStudent.RegNo ?? student.RegNo;
            student.Name = updatedStudent.Name ?? student.Name;
            student.Department = updatedStudent.Department ?? student.Department;
            student.DateRegistered = updatedStudent.DateRegistered ?? student.DateRegistered;

            _context.SaveChanges();
        }
        
        internal void Delete(int id)
        {
            var student = GetById(id) ?? throw new Exception("Student not found");
            _context.Students.Remove(student);

            _context.SaveChanges();
        }
    }


}

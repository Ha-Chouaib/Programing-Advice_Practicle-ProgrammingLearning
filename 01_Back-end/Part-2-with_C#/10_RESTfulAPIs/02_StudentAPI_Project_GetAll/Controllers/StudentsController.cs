using _02_StudentsAPI.DataSimulation;
using _02_StudentsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace _02_StudentsAPI.Controllers
{
    [ApiController]
    [Route("api/Students")]
    public class StudentsController : Controller
    {

        [HttpGet("All",Name = "GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return Ok(StudentData.StudentsList);
        }
        [HttpGet("Passed", Name = "GetPassedStudents")]
        public ActionResult<IEnumerable<Student>> GetPassedStudents()
        {
            return Ok(StudentData.StudentsList.Where(s => s.Grade >= 50).ToList());
        }


        [HttpGet ("AVG", Name = "GetAverageGrade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<double> GetAverageGrade()
        {
            //StudentData.StudentsList.Clear();
            if (StudentData.StudentsList.Count == 0) return NotFound("No Students Data Found!");
            double avg = StudentData.StudentsList.Average(s => s.Grade);
            return Ok(avg);
        }

        [HttpGet ("{Id}",Name ="GetStudentByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Student> GetStudentByID(int Id)
        {
            if (Id < 1) return BadRequest($"Id {Id} Not Accepted");

            var student = StudentData.StudentsList.FirstOrDefault(s => s.Id == Id);

            if (student == null) return NotFound($"No Student exist with id [{Id}] In The current context");

            return Ok(student);
        }


        [HttpPost (Name ="AddStudent")]
        [ProducesResponseType (StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Student> AddNewStudents(Student student)
        {
            if (!ValidateStudentRecord(student)) return BadRequest("Invalid Student data");

            student.Id = StudentData.StudentsList.Count > 0 ? StudentData.StudentsList.Max(s => s.Id) + 1 : 1;
            StudentData.StudentsList.Add(student);
            return CreatedAtRoute("GetStudentByID", new { id = student.Id }, student);
        }
        private bool ValidateStudentRecord(Student s)
        {
            if (s == null) return false;
            if(s.Id < 0) return false;
            if(string.IsNullOrEmpty(s.Name)) return false;
            if (s.Age < 0) return false;
            if(s.Grade < 0) return false;

            return true;
        }

        [HttpDelete ("{Id}",Name ="DeleteStudent")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public ActionResult DeleteStudent(int Id)
        {
            if (Id < 0) return BadRequest($"Invalid Id {Id}! Not Accepted");

            var Student = StudentData.StudentsList.FirstOrDefault(s => s.Id == Id);
            if (Student == null) return NotFound($"No Student Found With Id {Id}");
            StudentData.StudentsList.Remove(Student);
            return Ok($"The Student with Id {Id} has been deleted successfuly");

        }


        [HttpPut ("{Id}",Name ="UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Student> UpdateStudent(int Id,Student student)
        {
            if (!ValidateStudentRecord(student)) return BadRequest("Invalid Recored");

            var s = StudentData.StudentsList.FirstOrDefault(s => s.Id == Id);
            if (s == null) return NotFound($"No Student Found With Id {Id}");

            if(!UpdateStudent(s,student)) return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the student");


            return Ok(student);
        }

        private bool UpdateStudent(Student Old, Student New)
        {
            Old.Id = New.Id;
            Old.Name = New.Name;
            Old.Age = New.Age;
            Old.Grade = Old.Grade;
            return true;
        }
    }
}

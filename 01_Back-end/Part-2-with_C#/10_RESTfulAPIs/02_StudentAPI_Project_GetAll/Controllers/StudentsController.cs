using _02_StudentsAPI.DataSimulation;
using _02_StudentsAPI.Models;
using Microsoft.AspNetCore.Mvc;

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

    }
}

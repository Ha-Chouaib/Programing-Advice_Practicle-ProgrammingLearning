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
        public ActionResult<double> GetAverageGrade()
        {
            //StudentData.StudentsList.Clear();
            if (StudentData.StudentsList.Count == 0) return NotFound("No Students Data Found!");
            double avg = StudentData.StudentsList.Average(s => s.Grade);
            return Ok(avg);
        }
    }
}

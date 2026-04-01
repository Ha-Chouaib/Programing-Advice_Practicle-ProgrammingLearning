using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic;
using StudentAPIBusinessLayer;
using StudentDataAccessLayer;
using Microsoft.AspNetCore.Authorization;

namespace StudentApi.Controllers 
{
    [Authorize]
    [ApiController] // Marks the class as a Web API controller with enhanced features.
  //  [Route("[controller]")] // Sets the route for this controller to "students", based on the controller name.
    [Route("api/Students")]

    public class StudentsController : ControllerBase 
    {


        [HttpGet("All", Name ="GetAllStudents")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<StudentDTO>> GetAllStudents() 
        {

            List<StudentDTO> StudentsList = Student.GetAllStudents();
            if (StudentsList.Count == 0)
            {
                return NotFound("No Students Found!");
            }
            return Ok(StudentsList); 

        }

        
        [HttpGet("Passed",Name = "GetPassedStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<StudentDTO>> GetPassedStudents()

        {
            // var passedStudents = StudentDataSimulation.StudentsList.Where(student => student.Grade >= 50).ToList();

            List<StudentDTO>? PassedStudentsList = Student.GetPassedStudents();
            if (PassedStudentsList?.Count == 0)
            {
                return NotFound("No Students Found!");
            }

            return Ok(PassedStudentsList); // Return the list of students who passed.
        }

        
        [HttpGet("AverageGrade", Name = "GetAverageGrade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<double> GetAverageGrade()
        {
            //var averageGrade = StudentDataSimulation.StudentsList.Average(student => student.Grade);
            double  averageGrade = Student.GetAverageGrade();
            return Ok(averageGrade);
        }


        [HttpGet("{id}", Name = "GetStudentById")]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StudentDTO> GetStudentById(int id)
        {

            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            //var student = StudentDataSimulation.StudentsList.FirstOrDefault(s => s.Id == id);
            //if (student == null)
            //{
            //    return NotFound($"Student with ID {id} not found.");
            //}
            Student? student = Student.Find(id);

            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            //here we get only the DTO object to send it back.
            StudentDTO SDTO = student.SDTO;

            //we return the DTO not the student object.
            return Ok(SDTO);

        }


        
        [HttpPost(Name = "AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StudentDTO> AddStudent(StudentDTO newStudentDTO)
        {
            //we validate the data here
            if (newStudentDTO == null || string.IsNullOrEmpty(newStudentDTO.Name) || newStudentDTO.Age < 0 || newStudentDTO.Grade < 0)
            {
                return BadRequest("Invalid student data.");
            }

          //newStudent.Id = StudentDataSimulation.StudentsList.Count > 0 ? StudentDataSimulation.StudentsList.Max(s => s.Id) + 1 : 1;

          Student student = new Student( new StudentDTO(newStudentDTO.Id, newStudentDTO.Name, newStudentDTO.Age, newStudentDTO.Grade,
                                                                                newStudentDTO.Email,clsCryptography.PassowrdBcyptHashing(newStudentDTO.PasswordHash),newStudentDTO.Role ) ) ;
            student.Save();

            newStudentDTO.Id = student.ID;

            //we return the DTO only not the full student object
            //we dont return Ok here,we return createdAtRoute: this will be status code 201 created.
            return CreatedAtRoute("GetStudentById", new { id = newStudentDTO.Id }, newStudentDTO);

        }

       

        [HttpPut("{id}", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StudentDTO> UpdateStudent(int id, StudentDTO updatedStudent)
        {
            if (id < 1 || updatedStudent == null || string.IsNullOrEmpty(updatedStudent.Name) || updatedStudent.Age < 0 || updatedStudent.Grade < 0)
            {
                return BadRequest("Invalid student data.");
            }

            //var student = StudentDataSimulation.StudentsList.FirstOrDefault(s => s.Id == id);

           Student? student = Student.Find(id);
          

            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }


            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Grade = updatedStudent.Grade;
            student.Email = updatedStudent.Email;
            student.PasswordHash = clsCryptography.PassowrdBcyptHashing(updatedStudent.PasswordHash);
            student.Role = updatedStudent.Role;
            student.Save();

            //we return the DTO not the full student object.
            return Ok(student.SDTO);

        }


        [HttpDelete("{id}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteStudent(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            // var student = StudentDataSimulation.StudentsList.FirstOrDefault(s => s.Id == id);
            // StudentDataSimulation.StudentsList.Remove(student);

           if(Student.DeleteStudent(id))
            
                return Ok($"Student with ID {id} has been deleted.");
            else
                return NotFound($"Student with ID {id} not found. no rows deleted!");
        }

    }
}

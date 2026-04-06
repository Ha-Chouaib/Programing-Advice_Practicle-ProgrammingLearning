using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic;
using StudentAPIBusinessLayer;
using StudentDataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace StudentApi.Controllers 
{
    [Authorize]// Requires authentication for all endpoints in this controller by default.
    [ApiController] // Marks the class as a Web API controller with enhanced features.
  //  [Route("[controller]")] // Sets the route for this controller to "students", based on the controller name.
    [Route("api/Students")]
    public class StudentsController : ControllerBase 
    {
        private readonly ILogger<StudentsController> _logger;
        public StudentsController(ILogger<StudentsController> logger) 
        {
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]// Only users with the "Admin" role can access this endpoint.
        [HttpGet("All", Name ="GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

        [AllowAnonymous]// Allow anonymous access to this endpoint, overriding the [Authorize] attribute at the controller level.
        [HttpGet("Passed",Name = "GetPassedStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

        [AllowAnonymous]
        [HttpGet("AverageGrade", Name = "GetAverageGrade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id, [FromServices] IAuthorizationService authorizationService)
        {

            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            
            Student? student = Student.Find(id);

            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            var authResult = await authorizationService.AuthorizeAsync(User, id, "StudentOwnerOrAdmin");

            if(!authResult.Succeeded)return Forbid();
         

            //here we get only the DTO object to send it back.
            StudentDTO SDTO = student.SDTO;

            //we return the DTO not the student object.
            return Ok(SDTO);

        }

        
        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
                                                                                newStudentDTO.Email,clsCryptography.PassowrdBcyptHashing(newStudentDTO.PasswordHash),newStudentDTO.Role,
                                                                                newStudentDTO.RefreshTokenHash,newStudentDTO.RefreshTokenExpiresAt,newStudentDTO.RefreshTokenRevokedAt) ) ;
            student.Save();

            newStudentDTO.Id = student.ID;

            //we return the DTO only not the full student object
            //we dont return Ok here,we return createdAtRoute: this will be status code 201 created.
            return CreatedAtRoute("GetStudentById", new { id = newStudentDTO.Id }, newStudentDTO);

        }


        [Authorize(Roles = "Admin")]
        [HttpPut("{id}", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteStudent(int id)
        {
            // Capture IP once for tracing (helps investigations later)
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            // Identify the admin who is performing the action
            // ClaimTypes.NameIdentifier is what you put in JWT during login.
            var adminId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "unknown";
            if (id < 1)
            {
                _logger.LogWarning(
                                    "Admin action blocked (invalid id). AdminId={AdminId}, Action=DeleteStudent, TargetId={TargetId}, IP={IP}",
                                    adminId,
                                    id,
                                    ip);
                return BadRequest($"Not accepted ID {id}");
            }

            Student? student = Student.Find(id);
            if (student == null)
            {
                _logger.LogWarning(
                                    "Admin action blocked (student not found). AdminId={AdminId}, Action=DeleteStudent, TargetId={TargetId}, IP={IP}",
                                    adminId,
                                    id,
                                    ip);
                return NotFound($"Student with ID {id} not found.");
            }

            //Log Before Deletion for traceability (important for audits and investigations)
            //If DeleteStudent fails, we will know who attempted it and from where.
            _logger.LogInformation(
                                    "Admin action started. AdminId={AdminId}, Action=DeleteStudent, TargetId={TargetId}, TargetEmail={TargetEmail}, IP={IP}",
                                    adminId,
                                    student.ID,
                                    student.Email,
                                    ip
                                  );

            if (Student.DeleteStudent(id))
            {
                _logger.LogInformation(
                                    "Admin action successful. AdminId={AdminId}, Action=DeleteStudent, TargetId={TargetId}, TargetEmail={TargetEmail}, IP={IP}",
                                    adminId,
                                    student.ID,
                                    student.Email,
                                    ip
                                  );
                return Ok($"Student with ID {id} has been deleted.");
            }
                
            else
            {
                _logger.LogError(
                                    "Admin action failed (deletion error). AdminId={AdminId}, Action=DeleteStudent, TargetId={TargetId}, TargetEmail={TargetEmail}, IP={IP}",
                                    adminId,
                                    student.ID,
                                    student.Email,
                                    ip
                                  );
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while trying to delete student with ID {id}. Please try again later.");
            }
               
        }

    }
}

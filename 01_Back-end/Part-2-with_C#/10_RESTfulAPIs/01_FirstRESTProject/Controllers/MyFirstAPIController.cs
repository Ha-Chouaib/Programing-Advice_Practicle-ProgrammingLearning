using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01_FirstRESTProject.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/MyFirstAPI")]
    [ApiController]
    public class MyFirstAPIController : ControllerBase
    {
        [HttpGet ("MyName",Name ="MyName")]
        public string GetMyName()
        {
            return "My Name Is Chouaib Hadadi";
        }
        
        [HttpGet ("YourName",Name ="YourName")]
        public string GetyourName()
        {
            return "Your Name Is Mohammed Abu-Hadhoud";
        }

        [HttpGet("sum/{n1}/{n2}")]
        public int Sum(int n1, int n2)
        {
            return n1 + n2;
        }

        [HttpGet ("multiply/{n1}/{n2}")]
        public int Multipy(int n1, int n2) { return n1 * n2; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentAPIBusinessLayer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromBody] LoginRequest request)
        {
          
            //[0]
            var student =Student.Find(request.Email);

            //[1] check if a student with the provided email exists in the database. If not, return an Unauthorized response indicating invalid credentials.
            //This prevents attackers from knowing whether an email is registered or not, enhancing security by not revealing user existence information.
            if (student == null) return Unauthorized( "Invalid credentials.Ema" );

            //[2] check if the provided password matches the stored password hash using BCrypt. The Verify method takes the plaintext password and the stored hash, and returns true if they match, false otherwise.
            //This ensures that even if the database is compromised, attackers cannot easily retrieve plaintext passwords.
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, student.PasswordHash);

            if(!isPasswordValid) return Unauthorized("Invalid credentials.Pass");

            //[3] create claims for the JWT token, including user ID, email, and role.
            //These claims will be included in the token payload and can be used for authorization in subsequent requests.
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, student.ID.ToString()),
                new Claim(ClaimTypes.Email, student.Email),
                new Claim(ClaimTypes.Role, student.Role)
            };

            //[4] _ This key must be stored securely in a real application, e.g., in environment variables or a secrets manager not hardcoded in the source code.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_123456"));

            //[5] Here we specify the signing algorithm (HMAC SHA256) and the key to sign the JWT token.
            //This ensures that the token cannot be tampered with and can be verified by the server when received in subsequent requests.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //[6] create JWT token with claims, issuer, audience, expiration, and signing credentials
            var token = new JwtSecurityToken
                (
                    issuer: "StudentApi",
                    audience: "StudentApiUsers",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

            //[7] return the generated JWT token as a response to the client. The token is serialized to a string using JwtSecurityTokenHandler.WriteToken method,
            //which can be included in the Authorization header of subsequent requests for authentication and authorization purposes.
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentApi.DTOs.Auth;
using StudentAPIBusinessLayer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
            var student = Student.Find(request.Email);

            //[1] check if a student with the provided email exists in the database. If not, return an Unauthorized response indicating invalid credentials.
            //This prevents attackers from knowing whether an email is registered or not, enhancing security by not revealing user existence information.
            if (student == null) return Unauthorized("Invalid credentials.Ema");

            //[2] check if the provided password matches the stored password hash using BCrypt. The Verify method takes the plaintext password and the stored hash, and returns true if they match, false otherwise.
            //This ensures that even if the database is compromised, attackers cannot easily retrieve plaintext passwords.
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, student.PasswordHash);

            if (!isPasswordValid) return Unauthorized("Invalid credentials.Pass");

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
            //[7] generate the JWT token string using JwtSecurityTokenHandler and return it in the response.
            //The token can then be used by the client for authenticated requests to protected endpoints.
            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            //[8] generate a refresh token, which is a random string that can be used to obtain a new access token when the current one expires.
            //The refresh token should be stored securely in the database and associated with the user.
            var refreshToken = GenerateRefreshToken();

            student.UpdateRefreshTokenData(BCrypt.Net.BCrypt.HashPassword(refreshToken), DateTime.UtcNow.AddDays(7), null);

            return Ok(new TokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        [HttpPost("refresh")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Refresh([FromBody] RefreshRequest request)
        {
            var student = Student.Find(request.Email);

            if (student == null) return Unauthorized("Invalid refresh request");
            if (student.RefreshTokenRevokedAt != null) return Unauthorized("Refresh token revoked.");
            if (student.RefreshTokenExpiresAt == null || student.RefreshTokenExpiresAt <= DateTime.UtcNow) return Unauthorized("Refresh token expired.");

            bool isRefreshTokenValid = BCrypt.Net.BCrypt.Verify(request.RefreshToken, student.RefreshTokenHash);
            if (!isRefreshTokenValid) return Unauthorized("Invalid refresh token.");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, student.ID.ToString()),
                new Claim(ClaimTypes.Email, student.Email),
                new Claim(ClaimTypes.Role, student.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_123456"));

            var cerds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken
                (
                    issuer: "StudentApi",
                    audience: "StudentApiUsers",
                    claims: claims,
                    //expires: DateTime.Now.AddMinutes(30),//real application should set a reasonable expiration time for access tokens, e.g., 15-30 minutes, to balance security and usability.
                    expires: DateTime.UtcNow.AddSeconds(10),//for testing purpose, set the access token to expire in 10 seconds
                    signingCredentials: cerds
                    );
            var newAccessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            var newRefreshToken = GenerateRefreshToken();

            student.UpdateRefreshTokenData(BCrypt.Net.BCrypt.HashPassword(newRefreshToken), DateTime.UtcNow.AddDays(7), null);

            return Ok(new TokenResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout([FromBody] LogoutRequest request)
        {
            var student = Student.Find(request.Email);
            if (student == null) return Ok();//logout should be idempotent, so we return OK even if the user doesn't exist to prevent information disclosure about user existence.


            bool isRefreshTokenValid = BCrypt.Net.BCrypt.Verify(request.RefreshToken, student.RefreshTokenHash);
            if (!isRefreshTokenValid) return Ok();//if the refresh token is invalid, we still return OK to prevent information disclosure about token validity.

            student.RevokeRefreshToken(DateTime.UtcNow);
            return Ok("Logged out successfully.");

        }
    }
}

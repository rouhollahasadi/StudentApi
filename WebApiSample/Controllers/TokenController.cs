using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiSample.Controllers
{
    [Route("api/[controller]")]  // براکت بسته شد
    [ApiController]
    [ApiVersion("1", Deprecated = true)]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// دریافت توکن JWT
        /// </summary>
        /// <param name="username">نام کاربری</param>
        /// <param name="password">رمز عبور</param>
        /// <returns>توکن JWT</returns>
        [HttpPost("generate")]
        [AllowAnonymous]
        public IActionResult GenerateToken([FromBody] LoginRequest request)
        {
            // اعتبارسنجی کاربر (اینجا ساده شده)
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required");
            }

            // در دنیای واقعی، اینجا باید کاربر را از دیتابیس چک کنید
            if (request.Username != "admin" || request.Password != "123")
            {
                return Unauthorized("Invalid credentials");
            }

            try
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, request.Username),
                    new Claim(ClaimTypes.GivenName, "rouhollah"),
                    new Claim(ClaimTypes.Surname, "asadi"),
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JsonWebTokenConfig:Key"] ?? "YourSuperSecretKeyHere1234567890")
                );

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["JsonWebTokenConfig:Issuer"] ?? "YourIssuer",
                    audience: _configuration["JsonWebTokenConfig:Audience"] ?? "YourAudience",
                    expires: DateTime.Now.AddMinutes(
                        double.Parse(_configuration["JsonWebTokenConfig:ExpireTime"] ?? "60")
                    ),
                    notBefore: DateTime.Now,
                    claims: claims,
                    signingCredentials: credentials
                );

                var jsonWebToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new
                {
                    Token = jsonWebToken,
                    ExpiresIn = DateTime.Now.AddMinutes(
                        double.Parse(_configuration["JsonWebTokenConfig:ExpireTime"] ?? "60")
                    ),
                    TokenType = "Bearer"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating token: {ex.Message}");
            }
        }

        /// <summary>
        /// اعتبارسنجی توکن
        /// </summary>
        [HttpGet("validate")]
        [Authorize]
        public IActionResult ValidateToken()
        {
            var username = User.Identity?.Name;
            return Ok(new { Message = "Token is valid", User = username });
        }
    }

    // مدل درخواست
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
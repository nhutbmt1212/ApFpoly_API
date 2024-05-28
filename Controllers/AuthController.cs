using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ISinhVienDependency _sinhVienDependency;
        private readonly IGiangVienDependency _giangVienDependency;
        public AuthController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            ISinhVienDependency sinhVienDependency,
            IGiangVienDependency giangVienDependency,
            IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _sinhVienDependency = sinhVienDependency;
            _giangVienDependency = giangVienDependency;
            _configuration = configuration;
        }
        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    var sinhVien = _sinhVienDependency.LaySinhVienTheoEmail(email);
                    var giangVien = _giangVienDependency.LayGiangVienTheoEmail(email);
                    if (sinhVien != null)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim("UserId",sinhVien.MaSinhVien.ToString()),
                            new Claim("Email", email),
                            new Claim("Role", "Sinh viên"),
                            new Claim(ClaimTypes.Role, "Sinh viên")
                            };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(60),
                            signingCredentials: signIn
                        );
                    
                        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                        
                        return Ok(new { Token = tokenValue, User = sinhVien });
                    }
                    else if (giangVien != null)
                    {
                        var claims = new[]
                         {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim("UserId",giangVien.MaGiangVien.ToString()),
                            new Claim("Email", email),
                            new Claim("Role", giangVien.ChucVu == "Giảng viên"?"Giảng viên":"Admin"),
                            new Claim(ClaimTypes.Role,giangVien.ChucVu == "Giảng viên"?"Giảng viên":"Admin")
                            };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(60),
                            signingCredentials: signIn
                        );
                        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                        return Ok(new { Token = tokenValue, User = giangVien });
                    }
                }
                else
                {
                    return BadRequest("Không có user nào");
                }
            }

            return BadRequest("Lỗi login");
        }
      
    }
}

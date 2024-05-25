using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ISinhVienDependency _sinhVienDependency;
        private readonly IGiangVienDependency _giangVienDependency;
        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ISinhVienDependency sinhVienDependency, IGiangVienDependency giangVienDependency)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _sinhVienDependency = sinhVienDependency;
            _giangVienDependency = giangVienDependency;
        }
        [HttpPost,Route("Login")]
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
                    if(sinhVien != null)
                    {
                        var tokenHander = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes("ssdasdewqeqwe123123213123skdaskjdasjdasjsdasdsadas");
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.Name, user.Id.ToString())
                            }),
                            Expires = DateTime.UtcNow.AddMinutes(30),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHander.CreateToken(tokenDescriptor);
                        var tokenString = tokenHander.WriteToken(token);


                        return Ok(new { Token = tokenString });
                    }
                    else if(giangVien != null)
                    {
                        var tokenHander = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes("ssdasdewqeqwe123123213123skdaskjdasjdasjsdasdsadas");
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.Name, user.Id.ToString())
                            }),
                            Expires = DateTime.UtcNow.AddMinutes(30),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHander.CreateToken(tokenDescriptor);
                        var tokenString = tokenHander.WriteToken(token);


                        return Ok(new { Token = tokenString });
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

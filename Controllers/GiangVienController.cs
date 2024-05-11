using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        private readonly IGiangVienDependency _giangVien;
        public GiangVienController(IGiangVienDependency giangVien)
        {
            _giangVien = giangVien;
        }
        [HttpGet]
        public IActionResult GetAllGiangVien()
        {
            var result =_giangVien.LayGiangVien();
            return Ok(result);
        }

        [HttpGet, Route("GetGiangVienTheoId/{id}")]
        public IActionResult GetAllGiangVienTheoId(string id)
        {
            var result = _giangVien.LayGiangVienTheoMaGiangVien(id);
            return Ok(result);
        }
        [HttpPost, Route("ThemGiangVien")]
        public IActionResult ThemGiangVien(GiangVien giangVien)
        {
            try
            {
                var giangVienMoi = _giangVien.ThemGiangVien(giangVien);
                return Ok(new { success = true, data = giangVien });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpPut, Route("{id}")]
        public async Task<IActionResult> SuaGiangVien(string id, GiangVien giangVien)
        {
            try
            {
                var suaGiangVien = await _giangVien.SuaGiangVien(giangVien);
                return Ok(new { success = true, data = giangVien });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> XoaGiangVien(string id)
        {
            try
            {
                var xoaGiangVien = await _giangVien.XoaGiangVien(id);
                return Ok(new { success = true, message = xoaGiangVien });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}

using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly ISinhVienDependency _sinhVien;
        public SinhVienController(ISinhVienDependency sinhVien)
        {
             _sinhVien = sinhVien;
        }
        [HttpGet]
        public IActionResult GetAllSinhVien()
        {
          var result = _sinhVien.LaySinhVien();
            return Ok(result);
        }

        [HttpGet,Route("GetSinhVienTheoId/{id}")]
        public IActionResult GetAllSinhVienTheoId(string id) {
            var result = _sinhVien.LaySinhVienTheoMaSinhVien(id);
            return Ok(result);
        }
        [HttpPost,Route("ThemSinhVien")]
        public IActionResult ThemSinhVien(SinhVien sinhvien)
        {
            try
            {
                var sinhVienMoi = _sinhVien.ThemSinhVien(sinhvien);
                return Ok(new { success = true, data = sinhVienMoi }) ;
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false , message = ex.Message});
            }
        }
        [HttpPut,Route("{id}")]
        public async Task<IActionResult> SuaSinhVien(string id, SinhVien sinhVien)
        {
            try
            {
                var suaSinhVien = await _sinhVien.SuaSinhVien(sinhVien);
                return Ok(new { success = true, data = sinhVien });
            }
            catch(Exception ex)
            {
                return BadRequest(new { success = false ,message = ex.Message});
            }
        }
        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> XoaSinhVien(string id)
        {
            try {
                var xoaSinhVien = await _sinhVien.XoaSinhVien(id);
                return Ok(new { success = true, message = xoaSinhVien });
            }
            catch (Exception ex)
            {
                return BadRequest(new {success = false, message = ex.Message });
            }
        }
    }
}

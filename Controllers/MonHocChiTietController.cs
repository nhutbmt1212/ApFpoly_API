using ApFpoly_API.DTO;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocChiTietController : ControllerBase
    {
        private readonly IMonHocChiTietDependency _MonHocChiTiet;
        public MonHocChiTietController(IMonHocChiTietDependency MonHocChiTiet)
        {
            _MonHocChiTiet = MonHocChiTiet;
        }
        [HttpGet]
        public IActionResult GetAllMonHocChiTiet()
        {
            var result = _MonHocChiTiet.LayMonHocChiTiet();
            return Ok(result);
        }

        [HttpGet, Route("GetMonHocChiTietTheoId/{id}")]
        public IActionResult GetAllMonHocChiTietTheoId(string id)
        {
            var result = _MonHocChiTiet.LayMonHocChiTietTheoMonHocChiTiet(id);
            return Ok(result);
        }
        [HttpPost, Route("ThemMonHocChiTiet")]
        public IActionResult ThemMonHocChiTiet(MonHocChiTietDTO MonHocChiTiet)
        {
            try
            {
                var monHocChiTiet = new MonHocChiTiet
                {
                    MaMonHocChiTiet = MonHocChiTiet.MaMonHocChiTiet,
                  
                    MaMonHoc = MonHocChiTiet.MaMonHoc,
                    MaGiangVien = MonHocChiTiet.MaGiangVien,
                    MaPhong = MonHocChiTiet.MaPhong,
                    NgayBatDau = MonHocChiTiet.NgayBatDau,
                    NgayKetThuc = MonHocChiTiet.NgayKetThuc,
                    TinhTrang = MonHocChiTiet.TinhTrang,
                    MaHocKyBlock = MonHocChiTiet.MaHocKyBlock,

                };
                var MonHocChiTietMoi = _MonHocChiTiet.ThemMonHocChiTiet(monHocChiTiet);

                return Ok(new { success = true, data = MonHocChiTiet });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpPut, Route("{id}")]
        public async Task<IActionResult> SuaMonHocChiTiet(string id, MonHocChiTiet MonHocChiTiet)
        {
            try
            {
                var suaMonHocChiTiet = await _MonHocChiTiet.SuaMonHocChiTiet(MonHocChiTiet);
                return Ok(new { success = true, data = MonHocChiTiet });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> XoaMonHocChiTiet(string id)
        {
            try
            {
                var xoaMonHocChiTiet = await _MonHocChiTiet.XoaMonHocChiTiet(id);
                return Ok(new { success = true, message = xoaMonHocChiTiet });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}

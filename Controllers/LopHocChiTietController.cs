using ApFpoly_API.DTO;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopHocChiTietController : ControllerBase
    {
        private readonly ILopHocChiTietDependency _lopHocChiTietDependency;
     
        public LopHocChiTietController(ILopHocChiTietDependency lopHocChiTietDependency)
        {
            _lopHocChiTietDependency = lopHocChiTietDependency;
        }

        [HttpGet]
        public IActionResult GetAllLopHocChiTiet()
        {
            var result = _lopHocChiTietDependency.LayLopHocChiTiet();
            return Ok(result);
        }

        [HttpGet, Route("GetLopHocChiTietTheoId/{id}")]
        public IActionResult GetLopHocChiTietTheoId(string id)
        {
            var result = _lopHocChiTietDependency.LayLopHocChiTietTheoMa(id);
            return Ok(result);


        }
        [HttpGet, Route("KiemTraSinhVienCoTrongLopHoc")]
        public IActionResult KiemTraSinhVienCoTrongLopHoc( string MaLop,string MaSinhVien)
        {
            var result = _lopHocChiTietDependency.LayLopHocChiTietTheoMaLopVaMaSinhVien(MaLop, MaSinhVien);
            return Ok(result);
        }
        [HttpGet, Route("GetLopHocChiTietTheoIdLop/{id}")]
        public IActionResult GetLopHocChiTietTheoIdLop(string id)
        {
            var result = _lopHocChiTietDependency.LayLopHocChiTietTheoMaLop(id);
            return Ok(result);
        }
        [HttpGet("GetLopHocChiTietTheoMaSinhVien/{maSinhVien}")]
        public async Task<IActionResult> GetLopHocChiTietTheoMaSinhVien(string maSinhVien)
        {
            try
            {
                var lopHocChiTiets = await _lopHocChiTietDependency.LayLopHocChiTietTheoMaSinhVien(maSinhVien);
                return Ok(lopHocChiTiets);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost, Route("ImportExcelLopHocChiTiet")]
        public IActionResult ImportExcelLopHocChiTiet([FromForm] string MaLop, [FromForm] IFormFile fileExcel)
        {
            try { 
                  var result = _lopHocChiTietDependency.ImportSinhVienVaoLopHocChiTiet(MaLop, fileExcel);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            List<LopHocChiTiet> lopHocChiTiets = result.Data;
           

          
            return Ok(lopHocChiTiets);     }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
      
        }


        [HttpPost, Route("ThemLopHocChiTiet")]
        public IActionResult ThemLopHocChiTiet(List<LopHocChiTietDTO> lopHocChiTietList)
        {
            try
            {
                List<LopHocChiTiet> lopHocChiTiets = new List<LopHocChiTiet>();

                foreach (var lopHocChiTiet in lopHocChiTietList)
                {
                    var newLopHocChiTiet = new LopHocChiTiet
                    {
                        MaLopHocChiTiet = TaoMaLopHocChiTiet(),
                        MaLop = lopHocChiTiet.MaLop,
                        MaSinhVien = lopHocChiTiet.MaSinhVien,
                        TinhTrang = lopHocChiTiet.TinhTrang
                    };

                    lopHocChiTiets.Add(newLopHocChiTiet);
                }

                var addedLopHocChiTiet = _lopHocChiTietDependency.ThemLopHocChiTiet(lopHocChiTiets);

                return Ok(new { success = true, data = addedLopHocChiTiet });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        public static string TaoMaLopHocChiTiet()
        {
            var random = Path.GetRandomFileName();
            random = new string((from c in random
                                 where char.IsLetterOrDigit(c)
                                 select c).ToArray()).ToUpper();
            return random.Substring(0, 7);
        }




        [HttpPut, Route("{id}")]
        public async Task<IActionResult> SuaLopHocChiTiet(string id, LopHocChiTiet lopHocChiTiet)
        {
            try
            {
                var updatedLopHocChiTiet = await _lopHocChiTietDependency.SuaLopHocChiTiet(lopHocChiTiet);
                return Ok(new { success = true, data = updatedLopHocChiTiet });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost, Route("XoaLopHocChiTiet")]
        public async Task<IActionResult> XoaLopHocChiTiet(List<LopHocChiTietDTO> lopHocChiTietDTOs)
        {
            try
            {
                List<LopHocChiTiet> lopHocChiTiets = new List<LopHocChiTiet>();

                foreach (var lopHocChiTiet in lopHocChiTietDTOs)
                {
                    var xoaLopHocChiTiet = new LopHocChiTiet
                    {
                        MaLopHocChiTiet =lopHocChiTiet.MaLopHocChiTiet,
                        MaLop = lopHocChiTiet.MaLop,
                        MaSinhVien = lopHocChiTiet.MaSinhVien,
                        TinhTrang = "Đã xóa"
                    };

                    lopHocChiTiets.Add(xoaLopHocChiTiet);
                }

                var addedLopHocChiTiet = _lopHocChiTietDependency.XoaLopHocChiTiet(lopHocChiTiets);

                return Ok(new { success = true, data = addedLopHocChiTiet });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        

    }
}

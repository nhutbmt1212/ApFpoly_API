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
        [HttpGet, Route("GetLopHocChiTietTheoIdLop/{id}")]
        public IActionResult GetLopHocChiTietTheoIdLop(string id)
        {
            var result = _lopHocChiTietDependency.LayLopHocChiTietTheoMaLop(id);
            return Ok(result);
        }
        [HttpPost, Route("ImportExcelLopHocChiTiet")]
        public IActionResult ImportExcelLopHocChiTiet([FromForm] string MaLop, [FromForm] IFormFile fileExcel)
        {
            var result = _lopHocChiTietDependency.ImportSinhVienVaoLopHocChiTiet(MaLop, fileExcel);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            List<LopHocChiTiet> lopHocChiTiets = result.Data;
           

          
            return Ok(lopHocChiTiets);
        }


        [HttpPost, Route("ThemLopHocChiTiet")]
        public IActionResult ThemLopHocChiTiet(List<LopHocChiTiet> lopHocChiTietList)
        {
            try
            {
                List<LopHocChiTiet> lopHocChiTiets = new List<LopHocChiTiet>();

                foreach (var lopHocChiTiet in lopHocChiTietList)
                {
                    var newLopHocChiTiet = new LopHocChiTiet
                    {
                        MaLopHocChiTiet = lopHocChiTiet.MaLopHocChiTiet,
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

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> XoaLopHocChiTiet(string id)
        {
            try
            {
                var deletedLopHocChiTiet = await _lopHocChiTietDependency.XoaLopHocChiTiet(id);
                return Ok(new { success = true, message = deletedLopHocChiTiet });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}

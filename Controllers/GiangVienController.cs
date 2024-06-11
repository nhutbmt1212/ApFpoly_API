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
        static int soLuongGiangVien;
        public GiangVienController(IGiangVienDependency giangVien)
        {
            _giangVien = giangVien;
            soLuongGiangVien = _giangVien.SoLuongGiangVien();
        }
        [HttpGet]
        public IActionResult GetAllGiangVien()
        {
            var result =_giangVien.LayGiangVien();
            
            return Ok(result);
        }
        [HttpGet, Route("SearchingGiangVien")]
        public async Task<IActionResult> SearchingGiangVien(string searchString)
        {
            var listGiangViens = await _giangVien.SearchingGiangVien(searchString);

            return Ok(listGiangViens);
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
                string Base64String = giangVien.AnhGiangVien;
                giangVien.MaGiangVien = "GV" + (soLuongGiangVien + 1).ToString("D4");
                giangVien.AnhGiangVien = TaoTenFile(giangVien.MaGiangVien, Base64String);
                var giangVienMoi = _giangVien.ThemGiangVien(giangVien);
                XuLyAnhBase64(giangVien.AnhGiangVien, Base64String);
                return Ok(new { success = true, data = giangVienMoi });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        private string TaoTenFile(string TenFile, string base64String)
        {
            var parts = base64String.Split(',');
            string mediaType = parts[0];
            var format = mediaType.Split(';')[0].Split('/')[1];
            string fileName = $"Image_{TenFile}.{format}";
            return fileName;
        }

        private void XuLyAnhBase64(string TenFile, string base64String)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            var parts = base64String.Split(',');
            string base64 = parts[1];
            byte[] imageBytes = Convert.FromBase64String(base64);
            string filePath = Path.Combine(folderPath, TenFile);
            System.IO.File.WriteAllBytes(filePath, imageBytes);
        }

        [HttpPut, Route("{id}")]
        public IActionResult SuaGiangVien(string id, GiangVien giangVien)
        {
            try
            {
                var existingGiangVien = _giangVien.LayGiangVienTheoMaGiangVien(id);
                if (existingGiangVien.AnhGiangVien != giangVien.AnhGiangVien)
                {
                    string Base64String = giangVien.AnhGiangVien;
                    giangVien.AnhGiangVien = TaoTenFile(giangVien.MaGiangVien, Base64String);
                    XuLyAnhBase64(giangVien.AnhGiangVien, Base64String);
                }

                var suaGiangVien = _giangVien.SuaGiangVien(giangVien);
                return Ok(new { success = true, data = suaGiangVien });
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
        [HttpGet, Route("SearchingGiangVienForTimKiem")]
        public async Task<IActionResult> SearchingGiangVienForTimKiem(string searchString, int limitItem)
        {
            var listGiangViens = await _giangVien.SearchingGiangVienForTimKiem(searchString, limitItem);

            return Ok(listGiangViens);
        }
        [HttpGet("SoLuongGiangVien")]
        public IActionResult GetSoLuongGiangVien()
        {
            var soLuong = _giangVien.SoLuongGiangVien();
            return Ok(soLuong);
        }
        [HttpGet, Route("LayGiangVien")]
        public IEnumerable<GiangVien> GetGiangVien(int page, int pageSize)
        {
            var productPerPage = _giangVien.GetGiangVien(page, pageSize);
            return productPerPage;

        }
        [HttpGet, Route("ExportGiangVien")]
        public IActionResult ExportGiangVien()
        {
            var fileContents = _giangVien.ExportGiangVienToExcel();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "GiangVien.xlsx"
            );
        }

    }
}

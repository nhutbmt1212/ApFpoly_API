using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Net.NetworkInformation;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {

        private readonly ISinhVienDependency _sinhVien;
        static int soLuongSinhVien;
        public SinhVienController(ISinhVienDependency sinhVien)
        {
             _sinhVien = sinhVien;
            soLuongSinhVien = _sinhVien.SoLuongSinhVien();
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
              
                string Base64String = sinhvien.AnhSinhVien;
                DateTime now = new DateTime();
                sinhvien.MaSinhVien = "PK" + (soLuongSinhVien + 1).ToString("D4");
                sinhvien.AnhSinhVien = TaoTenFile(sinhvien.MaSinhVien, Base64String);
                var sinhVienMoi = _sinhVien.ThemSinhVien(sinhvien);
                XuLyAnhBase64(sinhvien.AnhSinhVien, Base64String);
                return Ok(new { success = true, data = sinhVienMoi }) ;
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false , message = ex.Message});
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

        private void XuLyAnhBase64(string TenFile,string base64String)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            var parts = base64String.Split(',');
            string base64 = parts[1];
            byte[] imageBytes = Convert.FromBase64String(base64);
            string filePath =Path.Combine(folderPath, TenFile);
            System.IO.File.WriteAllBytes(filePath, imageBytes);
        }

        [HttpPut, Route("{id}")]
        public  IActionResult SuaSinhVien(string id, SinhVien sinhVien)
        {
            try
            {
                var existingSinhVien =  _sinhVien.LaySinhVienTheoMaSinhVien(id);
                if (existingSinhVien.AnhSinhVien != sinhVien.AnhSinhVien)
                {
                    string Base64String = sinhVien.AnhSinhVien;
                    sinhVien.AnhSinhVien = TaoTenFile(sinhVien.MaSinhVien, Base64String);
                    XuLyAnhBase64(sinhVien.AnhSinhVien, Base64String);
                }

                var suaSinhVien =  _sinhVien.SuaSinhVien(sinhVien);
                return Ok(new { success = true, data = suaSinhVien });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
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

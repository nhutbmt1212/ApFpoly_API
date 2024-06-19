using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        private readonly IMonHocDependency _MonHoc;
        static int soLuongMonHoc;
        public MonHocController(IMonHocDependency MonHoc)
        {
            _MonHoc = MonHoc;
            soLuongMonHoc = _MonHoc.SoLuongMonHoc();
        }
        [HttpGet]
        public IActionResult GetAllMonHoc()
        {
            var result = _MonHoc.LayMonHoc();
            return Ok(result);
        }
        [HttpGet, Route("SearchingMonHoc")]
        public async Task<IActionResult> SearchingMonHoc(string searchString)
        {
            var listMonHocs = await _MonHoc.SearchingMonHoc(searchString);

            return Ok(listMonHocs);
        }
        [HttpGet, Route("GetMonHocTheoId/{id}")]
        public IActionResult GetAllMonHocTheoId(string id)
        {
            var result = _MonHoc.LayMonHocTheoMaMonHoc(id);
            return Ok(result);
        }
        [HttpPost, Route("ThemMonHoc")]
        public IActionResult ThemMonHoc(MonHoc MonHoc)
        {
            try
            {
                MonHoc.MaMonHoc = "MH" + (soLuongMonHoc + 1).ToString("D4");
                var  MonHocMoi = _MonHoc.ThemMonHoc(MonHoc);
          
                return Ok(new { success = true, data = MonHoc });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        // api lưu file môn học
        [HttpPost,Route("LuuFileMonHoc")]
        public async Task<IActionResult> LuuFileMonHoc(IFormFile fileMonHoc)
        {
            string filename = "";
            try
            {
                filename = fileMonHoc.FileName;
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "UploadDocument");
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);

                }
                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "UploadDocument", filename);
                using (var stream = new FileStream(exactpath,FileMode.Create)) {
                    await fileMonHoc.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok("Lưu file thành công");
        }
        [HttpGet,Route("DownloadFile/{idMonHoc}")]
        public async Task<IActionResult> DownloadFile(string idMonHoc)
        {
            var monHoc =  _MonHoc.LayMonHocTheoMaMonHoc(idMonHoc);
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "UploadDocument",monHoc?.TaiLieu);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            return File(bytes, contentType, Path.GetFileName(filepath));

        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> SuaMonHoc(string id, MonHoc MonHoc)
        {
            try
            {
                var suaMonHoc = await _MonHoc.SuaMonHoc(MonHoc);
                return Ok(new { success = true, data = MonHoc });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> XoaMonHoc(string id)
        {
            try
            {
                var xoaMonHoc = await _MonHoc.XoaMonHoc(id);
                return Ok(new { success = true, message = xoaMonHoc });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpGet("SoLuongMonHoc")]
        public IActionResult GetSoLuongMonHoc()
        {
            var soLuong = _MonHoc.SoLuongMonHoc();
            return Ok(soLuong);
        }
        [HttpGet, Route("LayMonHoc")]
        public IEnumerable<MonHoc> GetMonHoc(int page, int pageSize)
        {
            var productPerPage = _MonHoc.GetMonHoc(page, pageSize);
            return productPerPage;
        }
        [HttpGet, Route("SearchingMonHocForTimKiem")]
        public async Task<IActionResult> SearchingMonHocForTimKiem(string searchString, int limitItem)
        {
            var listStudents = await _MonHoc.SearchingMonHocForTimKiem(searchString, limitItem);

            return Ok(listStudents);
        }
        [HttpGet, Route("ExportMonHoc")]
        public IActionResult ExportGiangVien()
        {
            var fileContents = _MonHoc.ExportMonHocToExcel();

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
        static private Dictionary<string, string> listUrlEncode = new Dictionary<string, string>();
        [HttpPost, Route("EncodeUrlMonHoc")]
        public IActionResult EncodeUrlChiTietMonHoc(string MaLop, string TenLop, string MaMonHoc, string TenMonHoc)
        {
            try
            {
                listUrlEncode[TenLop] = MaLop.ToUpper();
                listUrlEncode[TenMonHoc] = MaMonHoc.ToUpper();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet,Route("DecodeUrlMonHoc")]
        public IActionResult DecodeUrlMonHoc(string encodeTenLopHoc,string encodeTenMonHoc)
        {
            try
            {
                var maLopHoc = listUrlEncode[encodeTenLopHoc.ToUpper()];
                var maMonHoc = listUrlEncode[encodeTenMonHoc.ToUpper()];
                return Ok(new { maLopHoc,maMonHoc });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

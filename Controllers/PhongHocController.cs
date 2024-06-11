using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongHocController : ControllerBase
    {
        private readonly IPhongHocDependency _PhongHoc;
        public PhongHocController(IPhongHocDependency PhongHoc)
        {
            _PhongHoc = PhongHoc;
        }
        [HttpGet]
        public IActionResult GetAllPhongHoc()
        {
            var result = _PhongHoc.LayPhongHoc();
            return Ok(result);
        }
        [HttpGet, Route("SearchingPhongHoc")]
        public async Task<IActionResult> SearchingPhongHoc(string searchString)
        {
            var listPhongHocs = await _PhongHoc.SearchingPhongHoc(searchString);

            return Ok(listPhongHocs);
        }

        [HttpGet, Route("GetPhongHocTheoId/{id}")]
        public IActionResult GetAllPhongHocTheoId(string id)
        {
            var result = _PhongHoc.LayPhongHocTheoMaPhongHoc(id);
            return Ok(result);
        }
        [HttpPost, Route("ThemPhongHoc")]
        public IActionResult ThemPhongHoc(PhongHoc PhongHoc)
        {
            try
            {
                var PhongHocMoi = _PhongHoc.ThemPhongHoc(PhongHoc);
                return Ok(new { success = true, data = PhongHocMoi });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpPut, Route("{id}")]
        public async Task<IActionResult> SuaPhongHoc(string id, PhongHoc PhongHoc)
        {
            try
            {
                var suaPhongHoc = await _PhongHoc.SuaPhongHoc(PhongHoc);
                return Ok(new { success = true, data = PhongHoc });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> XoaPhongHoc(string id)
        {
            try
            {
                var xoaPhongHoc = await _PhongHoc.XoaPhongHoc(id);
                return Ok(new { success = true, message = xoaPhongHoc });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpGet("SoLuongPhongHoc")]
        public IActionResult GetSoLuongPhongHoc()
        {
            var soLuong = _PhongHoc.SoLuongPhongHoc();
            return Ok(soLuong);
        }
        [HttpGet, Route("LayPhongHoc")]
        public IEnumerable<PhongHoc> GetPhongHoc(int page, int pageSize)
        {
            var productPerPage = _PhongHoc.GetPhongHoc(page, pageSize);
            return productPerPage;
        }

        [HttpGet, Route("SearchingPhongHocForTimKiem")]
        public async Task<IActionResult> SearchingPhongHocForTimKiem(string searchString, int limitItem)
        {
            var listStudents = await _PhongHoc.SearchingPhongHocForTimKiem(searchString, limitItem);

            return Ok(listStudents);
        }
        [HttpGet, Route("ExportPhongHoc")]
        public IActionResult ExportGiangVien()
        {
            var fileContents = _PhongHoc.ExportPhongHocToExcel();

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



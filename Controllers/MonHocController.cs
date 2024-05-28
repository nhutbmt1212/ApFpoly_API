using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        private readonly IMonHocDependency _MonHoc;
        public MonHocController(IMonHocDependency MonHoc)
        {
            _MonHoc = MonHoc;
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
                
                      var  MonHocMoi = _MonHoc.ThemMonHoc(MonHoc);
          
                return Ok(new { success = true, data = MonHoc });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
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
    }
}

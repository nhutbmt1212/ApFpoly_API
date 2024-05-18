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
    public class LopHocController : ControllerBase
    {
        private readonly ILopHocDependency _lopHocDependency;

        public LopHocController(ILopHocDependency lopHocDependency)
        {
            _lopHocDependency = lopHocDependency;
        }

        [HttpGet]
        public IActionResult GetAllLopHoc()
        {
            var result = _lopHocDependency.LayLopHoc();
            return Ok(result);
        }

        [HttpGet, Route("GetLopHocTheoId/{id}")]
        public IActionResult GetLopHocTheoId(string id)
        {
            var result = _lopHocDependency.LayLopHocTheoMa(id);
            return Ok(result);
        }


        [HttpPost, Route("ThemLopHoc")]
        public IActionResult ThemLopHoc(LopHoc lopHoc)
        {
            try
            {
              

                var addedLopHoc = _lopHocDependency.ThemLopHoc(lopHoc);

                return Ok(new { success = true, data = addedLopHoc });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> SuaLopHoc(string id, LopHoc lopHoc)
        {
            try
            {
                lopHoc.MaLop = id; // Ensure the ID is correctly set
                var updatedLopHoc = await _lopHocDependency.SuaLopHoc(lopHoc);
                return Ok(new { success = true, data = updatedLopHoc });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> XoaLopHoc(string id)
        {
            try
            {
                var deletedLopHoc = await _lopHocDependency.XoaLopHoc(id);
                return Ok(new { success = true, message = deletedLopHoc });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}

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
    public class HocKyBlockController : ControllerBase
    {
        private readonly IHocKyBlockDependency _hocKyBlockDependency;

        public HocKyBlockController(IHocKyBlockDependency hocKyBlockDependency)
        {
            _hocKyBlockDependency = hocKyBlockDependency;
        }

        [HttpGet]
        public IActionResult GetAllHocKyBlock()
        {
            var result = _hocKyBlockDependency.LayHocKyBlock();
            return Ok(result);
        }

        [HttpGet, Route("GetHocKyBlockTheoMa/{MaHocKyBlock}")]
        public IActionResult GetHocKyBlockTheoMa(string MaHocKyBlock)
        {
            var result = _hocKyBlockDependency.LayHocKyBlockTheoMa(MaHocKyBlock);
            return Ok(result);
        }

        [HttpGet, Route("GetHocKyBlockHienTai")]
        public IActionResult GetHocKyBlockHienTai()
        {
            var result = _hocKyBlockDependency.LayHocKyBlockHienTai();
            return Ok(result);
        }

        [HttpPost, Route("ThemHocKyBlock")]
        public IActionResult ThemHocKyBlock(HocKyBlock hocKyBlock)
        {
            try
            {
                var addedHocKyBlock = _hocKyBlockDependency.ThemHocKyBlock(hocKyBlock);
                return Ok(new { success = true, data = addedHocKyBlock });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPut, Route("{MaHocKyBlock}")]
        public async Task<IActionResult> SuaHocKyBlock(string MaHocKyBlock, HocKyBlock hocKyBlock)
        {
            try
            {
                hocKyBlock.MaHocKyBlock = MaHocKyBlock; // Ensure the ID is correctly set
                var updatedHocKyBlock = await _hocKyBlockDependency.SuaHocKyBlock(hocKyBlock);
                return Ok(new { success = true, data = updatedHocKyBlock });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpDelete, Route("{MaHocKyBlock}")]
        public async Task<IActionResult> XoaHocKyBlock(string MaHocKyBlock)
        {
            try
            {
                var deletedHocKyBlock = await _hocKyBlockDependency.XoaHocKyBlock(MaHocKyBlock);
                return Ok(new { success = true, message = deletedHocKyBlock });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}

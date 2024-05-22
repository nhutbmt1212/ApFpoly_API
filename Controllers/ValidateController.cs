using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly IValidateDependency _validateDependency;
        public ValidateController(IValidateDependency validateDependency)
        {
             _validateDependency = validateDependency;

        }
        [HttpGet,Route("ValidateTrungEmailTrongHeThong")]
        public IActionResult ValidateTrungEmailTrongHeThong(string email)
        {
            bool result = _validateDependency.KiemTraTrungEmailTrongHeThong(email);
           return Ok(result);
        }
        [HttpGet, Route("ValidateTrungSoDienThoaiTrongHeThong")]
        public IActionResult ValidateTrungSoDienThoaiTrongHeThong(string soDienThoai)
        {
            bool result = _validateDependency.KiemTraTrungSoDienThoaiTrongHeThong(soDienThoai);
            return Ok(result);

        }
        [HttpGet, Route("ValidateTrungCCCDTrongHeThong")]
        public IActionResult ValidateTrungCCCDTrongHeThong(string cccd)
        {
            bool result = _validateDependency.KiemTraTrungCCCDTrongHeThong(cccd);
            return Ok(result);
        }

        [HttpGet, Route("ValidateTrungEmailTrongHeThongTruEmailHienTai")]
        public IActionResult ValidateTrungEmailTrongHeThongTruEmailHienTai(string MaNguoiDung, string email)
        {
            bool result = _validateDependency.ValidateTrungEmailTrongHeThongTruEmailHienTai(MaNguoiDung,email);
            return Ok(result);
        }
        [HttpGet, Route("ValidateTrungSoDienThoaiTrongHeThongTruSoDienThoaiHienTai")]
        public IActionResult ValidateTrungSoDienThoaiTrongHeThongTruSoDienThoaiHienTai(string MaNguoiDung, string soDienThoai)
        {
            bool result = _validateDependency.ValidateTrungSoDienThoaiTrongHeThongTruSoDienThoaiHienTai(MaNguoiDung,soDienThoai);
            return Ok(result);

        }
        [HttpGet, Route("ValidateTrungCCCDTrongHeThongTruCCCDHienTai")]
        public IActionResult ValidateTrungCCCDTrongHeThongTruCCCDHienTai(string MaNguoiDung, string cccd)
        {
            bool result = _validateDependency.ValidateTrungCCCDTrongHeThongTruCCCDHienTai(MaNguoiDung, cccd);
            return Ok(result);
        }
    }
}

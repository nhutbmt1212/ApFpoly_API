using ApFpoly_API.DTO;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NopBaiController : ControllerBase
    {
        private readonly INopBaiDependency _nopBaiDependency;
        public NopBaiController(INopBaiDependency nopBaiDependency)
        {
            _nopBaiDependency = nopBaiDependency;

        }
        [HttpPost, Route("ThemNopBai")]
        public async Task<IActionResult> ThemNopBai(NopBaiDTO nopBaiDTO)
        {
            try
            {
                var nopBaiConverted = new NopBai
                {
                    MaNopBai = TaoNopBaiHoc(),
                    MaLop = nopBaiDTO.MaLop,
                    MaMonHoc = nopBaiDTO.MaMonHoc,
                    MaSinhVien = nopBaiDTO.MaSinhVien,
                    MaGiangVien = nopBaiDTO.MaGiangVien, 
                    TenFileNop = nopBaiDTO.TenFileNop,
                    PhuongThucNopBai = nopBaiDTO.PhuongThucNopBai,
                    NgayTao = nopBaiDTO.NgayTao,
                    TinhTrang = nopBaiDTO.TinhTrang
                };
                var nopBai = await _nopBaiDependency.ThemNopBai(nopBaiConverted);
                return Ok(nopBai);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        // api lưu file môn học
        [HttpPost, Route("LuuFileNopBai")]
        public async Task<IActionResult> LuuFileNopBai(IFormFile fileMonHoc)
        {
            string filename = "";
            try
            {
                filename = fileMonHoc.FileName;
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "UploadNopBai");
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);

                } 
                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "UploadNopBai", filename);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await fileMonHoc.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok("Lưu file thành công");
        }
        public static string TaoNopBaiHoc()
        {
            var random = Path.GetRandomFileName();
            random = new string((from c in random
                                 where char.IsLetterOrDigit(c)
                                 select c).ToArray()).ToUpper();
            return random.Substring(0, 7);
        }

        [HttpGet,Route("GetNopBaiTheoIdLopVaMonHoc")]
        public async Task<IActionResult> GetNopBaiTheoIdLopVaMonHoc(string MaLop, string MaMonHoc)
        {
            try
            {
                var nopBai = await _nopBaiDependency.GetNopBaiTheoIdLopVaMonHoc(MaLop, MaMonHoc);
                return Ok(nopBai);
            }
            catch ( Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut,Route("SuaNopBai")]
        public async Task<IActionResult> SuaNopBai(NopBaiDTO nopBaiDTO)
        {
            try
            {
                var nopBaiConverted = new NopBai
                {
                    MaNopBai = nopBaiDTO.MaNopBai,
                    MaLop = nopBaiDTO.MaLop,
                    MaMonHoc = nopBaiDTO.MaMonHoc,
                    MaSinhVien = nopBaiDTO.MaSinhVien,
                    MaGiangVien = nopBaiDTO.MaGiangVien,
                    TenFileNop = nopBaiDTO.TenFileNop,
                    PhuongThucNopBai = nopBaiDTO.PhuongThucNopBai,
                    NgayTao = nopBaiDTO.NgayTao,
                    TinhTrang = nopBaiDTO.TinhTrang
                };
                return Ok(nopBaiConverted);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet,Route("LayBaiNopTheoSinhVien")]
        public async Task<IActionResult> LayBaiNopTheoSinhVien (string MaSinhVien,string MaLop, string MaMonHoc)
        {
            try
            {
                var nopBai = await _nopBaiDependency.LayBaiNopTheoSinhVien(MaSinhVien, MaLop, MaMonHoc);
                return Ok(nopBai);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut,Route("SuaBaiDaNopCuaSinhVien")]
        public async Task<IActionResult> SuaBaiDaNopCuaSinhVien(NopBaiDTO nopBaiDTO)
        {
            try
            {
                var nopBaiConverted = new NopBai
                {
                    MaNopBai = nopBaiDTO.MaNopBai,
                    MaLop = nopBaiDTO.MaLop,
                    MaMonHoc = nopBaiDTO.MaMonHoc,
                    MaSinhVien = nopBaiDTO.MaSinhVien,
                    MaGiangVien = nopBaiDTO.MaGiangVien,
                    TenFileNop = nopBaiDTO.TenFileNop,
                    PhuongThucNopBai = nopBaiDTO.PhuongThucNopBai,
                    NgayTao = nopBaiDTO.NgayTao,
                    TinhTrang = nopBaiDTO.TinhTrang
                };
                var responseNopBai = await _nopBaiDependency.SuaNopBai(nopBaiConverted);
                return Ok(responseNopBai);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

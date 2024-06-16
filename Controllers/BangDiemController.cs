using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApFpoly_API.DTO;
using ApFpoly_API.Model;
using System.Net.WebSockets;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BangDiemController : ControllerBase
    {
        private readonly IBangDiemDependency _bangDiemDependency;
        public BangDiemController(IBangDiemDependency bangDiemDependency)
        {
            _bangDiemDependency = bangDiemDependency;
        }
        [HttpPost,Route("ThemBangDiem")]
        public async Task<IActionResult> ThemBangDiem(BangDiemDTO bangDiemDTO)
        {
            try
            {
                var bangDiemConverted = new BangDiem
                {
                    MaBangDiem = TaoMaBangDiem(),
                    MaLop = bangDiemDTO.MaLop,
                    MaSinhVien = bangDiemDTO.MaSinhVien,
                    MaMonHoc = bangDiemDTO.MaMonHoc,
                    MaGiangVien = bangDiemDTO.MaGiangVien,
                    Diem = bangDiemDTO.Diem,
                    NgayTao = bangDiemDTO.NgayTao,
                    TinhTrang = bangDiemDTO.TinhTrang,
                };
                var bangDiemDaDuocThem = await _bangDiemDependency.ThemBangDiem(bangDiemConverted);
                return Ok(bangDiemDaDuocThem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public static string TaoMaBangDiem()
        {
            var random = Path.GetRandomFileName();
            random = new string((from c in random
                                 where char.IsLetterOrDigit(c)
                                 select c).ToArray()).ToUpper();
            return random.Substring(0, 7);
        }

        [HttpGet,Route("LayBangDiemTheoIdLop")]
        public async Task<IActionResult> LayBangDiemTheoIdLop(string MaLop)
        {
            try
            {
                var bangDiems =await _bangDiemDependency.LayBangDiemTheoIdLop(MaLop);
                return Ok(bangDiems);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut,Route("SuaBangDiemChoSinhVien")]
        public async Task<IActionResult> SuaBangDiemChoSinhVien(string MaLop, string MaSinhVien,string MaMonHoc,double Diem)
        {
            try
            {
                var bangDiem = await _bangDiemDependency.SuaDiemChoSinhVien(MaLop, MaSinhVien, MaMonHoc,Diem);
                return Ok(bangDiem);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet,Route("LayDiemTheoSinhVien")]
        public async Task<IActionResult> LayDiemTheoSinhVien(string MaLop, string MaSinhVien, string MaMonHoc)
        {
            try
            {
                var bangDiem = await _bangDiemDependency.LayDiemTheoSinhVien(MaLop, MaSinhVien, MaMonHoc);
                return Ok(bangDiem);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet, Route("LayBangDiem")]
        public async Task<IActionResult> LayBangDiem()
        {
            try
            {
                var bangDiems = await _bangDiemDependency.LayBangDiem();
                return Ok(bangDiems);
            }
            catch (Exception ex)
            {
return BadRequest(ex);
            }
        }
        [HttpGet,Route("LayBangDiemTheoId/{MaLop}/{MaMonHoc}")]
        public async Task<IActionResult> LayBangDiemTheoId(string MaLop, string MaMonHoc)
        {
            try {
                var bangDiems = await _bangDiemDependency.LayBangDiemTheoId(MaLop, MaMonHoc);
                return Ok(bangDiems);
                 }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

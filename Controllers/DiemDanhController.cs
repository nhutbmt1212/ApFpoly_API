using ApFpoly_API.DTO;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemDanhController : ControllerBase
    {
        private readonly IDiemDanhDependency _diemDanhDependency;
        public DiemDanhController(IDiemDanhDependency diemDanhDependency)
        {
            _diemDanhDependency = diemDanhDependency;
        }

        [HttpGet, Route("LayDiemDanhTuMaLichHoc/{MaLichHoc}")]
        public async Task<IActionResult> LayDiemDanhTuMaLichHoc(string MaLichHoc)
        {
            try
            {
                var diemDanh = await _diemDanhDependency.LayDiemDanhTuMaLichHoc(MaLichHoc);

                return Ok(diemDanh);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost, Route("LuuDiemDanh")]
        public async Task<IActionResult> LuuDiemDanh(List<DiemDanhDTO> diemDanhsDTO)
        {
            try
            {
                List<DiemDanh> listDiemDanhConverted = new List<DiemDanh>();
                foreach (var item in diemDanhsDTO)
                {
                    var diemDanhConverted = new DiemDanh
                    {
                        MaDiemDanh = TaoMaDiemDanh(),
                        MaLichHoc = item.MaLichHoc,
                        MaSinhVien = item.MaSinhVien,
                        MaMonHoc = item.MaMonHoc,
                        MaGiangVien = item.MaGiangVien,
                        CoMat = item.CoMat == "Có mặt" ? true : false,
                        NgayTao = item.NgayTao,
                        TinhTrang = item.TinhTrang,

                    };
                    listDiemDanhConverted.Add(diemDanhConverted);

                }

                var diemDanhs = await _diemDanhDependency.LuuDiemDanh(listDiemDanhConverted);
                return Ok(diemDanhs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut, Route("SuaDiemDanh")]
        public async Task<IActionResult> SuaDiemDanh(List<DiemDanhDTO> diemDanhsDTO)
        {
            try
            {
                List<DiemDanh> listDiemDanhConverted = new List<DiemDanh>();
                foreach (var item in diemDanhsDTO)
                {
                    var diemDanhConverted = new DiemDanh
                    {
                        MaDiemDanh = item.MaDiemDanh,
                        MaLichHoc = item.MaLichHoc,
                        MaSinhVien = item.MaSinhVien,
                        MaMonHoc = item.MaMonHoc,
                        MaGiangVien = item.MaGiangVien,
                        CoMat = item.CoMat == "Có mặt" ? true : false,
                        NgayTao = item.NgayTao,
                        TinhTrang = item.TinhTrang,

                    };
                    listDiemDanhConverted.Add(diemDanhConverted);

                }

                var diemDanhs = await _diemDanhDependency.SuaDiemDanh(listDiemDanhConverted);
                return Ok(diemDanhs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public static string TaoMaDiemDanh()
        {
            var random = Path.GetRandomFileName();
            random = new string((from c in random
                                 where char.IsLetterOrDigit(c)
                                 select c).ToArray()).ToUpper();
            return random.Substring(0, 7);
        }
        [HttpGet, Route("KiemTraDiemDanhChoSinhVien")]
        public async Task<IActionResult> KiemTraDiemDanhChoSinhVien(string MaSinhVien, string MaLichHoc)
        {
            try
            {
                var diemDanh =await _diemDanhDependency.KiemTraDiemDanhChoSinhVien(MaSinhVien, MaLichHoc);
                return Ok(diemDanh);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}

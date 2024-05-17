using ApFpoly_API.DTO;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichHocController : ControllerBase
    {
        private readonly ILichHocDependency _lichHocDependency;

        public LichHocController(ILichHocDependency lichHocDependency)
        {
            _lichHocDependency = lichHocDependency;
        }

        [HttpGet]
        public IActionResult LayDanhSachLichHoc()
        {
            var danhSachLichHoc = _lichHocDependency.LayDanhSachLichHoc();
            return Ok(danhSachLichHoc);
        }

        [HttpGet("{id}")]
        public IActionResult LayLichHocTheoId(string id)
        {
            var lichHoc = _lichHocDependency.LayLichHocTheoId(id);
            if (lichHoc == null)
            {
                return NotFound();
            }
            return Ok(lichHoc);
        }
        [HttpPost]
        public IActionResult ThemLichHoc(LichHocDTO lichHocChiTietDto)
        {
            try
            {
                List<LichHoc> listLichHoc = new List<LichHoc>();
                foreach (var ngay in lichHocChiTietDto.NgayLichHoc)
                {
                    var lichHocChiTiet = new LichHoc
                    {
                        MaLichHoc = TaoMaLichHoc(),
                        ThoiGianBatDau = ngay.Date + lichHocChiTietDto.GioBatDau.ToTimeSpan(),
                        ThoiGianKetThuc = ngay.Date + lichHocChiTietDto.GioKetThuc.ToTimeSpan(),
                        TinhTrang = lichHocChiTietDto.TinhTrang,
                        MaLop = lichHocChiTietDto.MaLop,
                        MaHocKyBlock = lichHocChiTietDto.MaHocKyBlock,
                        MaPhong = lichHocChiTietDto.MaPhong,
                        MaGiangVien = lichHocChiTietDto.MaGiangVien,
                        MaMonHoc = lichHocChiTietDto.MaMonHoc
                    };
                    listLichHoc.Add(lichHocChiTiet);
                }
                var lichHocMoi = _lichHocDependency.ThemLichHoc(listLichHoc);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public static string TaoMaLichHoc()
        {
            var random = Path.GetRandomFileName();
            random = new string((from c in random
                                 where char.IsLetterOrDigit(c)
                                 select c).ToArray()).ToUpper();
            return random.Substring(0, 7);
        }
        [HttpPut("{id}")]
        public IActionResult SuaLichHoc(string id, LichHoc lichHoc)
        {
            if (id != lichHoc.MaLichHoc)
            {
                return BadRequest();
            }
            try
            {
                var lichHocSua = _lichHocDependency.SuaLichHoc(lichHoc);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult XoaLichHoc(string id)
        {
            var lichHoc = _lichHocDependency.XoaLichHoc(id);
            if (lichHoc == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

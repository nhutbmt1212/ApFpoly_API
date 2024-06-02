﻿using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApFpoly_API.DTO;
using ApFpoly_API.Model;

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
    }
}
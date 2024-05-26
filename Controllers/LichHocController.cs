using ApFpoly_API.DTO;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApFpoly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichHocController : ControllerBase
    {

        private readonly ILichHocDependency _lichHocDependency;
        private readonly IHocKyBlockDependency _hocKyBlockDependency;


        public LichHocController(ILichHocDependency lichHocDependency, IHocKyBlockDependency hocKyBlockDependency)
        {
            _lichHocDependency = lichHocDependency;
            _hocKyBlockDependency = hocKyBlockDependency;
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
        [HttpGet, Route("LayLichHocTheoIdLop/{id}")]
        public async Task<IActionResult> LayLichHocTheoIdLop(string id)
        {
            var lichHocs = await _lichHocDependency.LayLichHocTheoIdLop(id);
            return Ok(lichHocs);
        }

        [HttpGet("LayLichHocTheoMaHocKyBlockVaMaLop/{id}")]
        public IActionResult LayLichHocTheoMaHocKyBlockVaMaLop(string id)
        {
            var hocKyBlockHienTai = _hocKyBlockDependency.LayHocKyBlockHienTai();
            var hocKyBlockVaLop = new HocKyBlockVaLopDTO();
            hocKyBlockVaLop.MaLop = id;
            hocKyBlockVaLop.MaHocKyBlock = hocKyBlockHienTai.MaHocKyBlock;

            var lichHoc = _lichHocDependency.LayLichHocTheoMaHocKyBlockVaLop(hocKyBlockVaLop);
            if (lichHoc == null)
            {
                return NotFound();
            }
            return Ok(lichHoc);
        }

        [HttpGet, Route("LayLichHocTheoMaLopVaMaHocKyBlock")]
        public async Task<IActionResult> LayLichHocTheoMaLopVaMaHocKyBlock(string MaLop, string MaHocKyBlock)
        {
            var lichHocs = await _lichHocDependency.LayLichHocTheoMaLopVaMaHocKyBlock(MaLop, MaHocKyBlock);
            return Ok(lichHocs);
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

        [HttpPut, Route("SuaLichHoc")]
        public async Task<IActionResult> SuaLichHoc(LichHocDTO lichHocChiTietDto)
        {
            try
            {
                List<LichHoc> listLichHoc = new List<LichHoc>();
                foreach (var ngay in lichHocChiTietDto.NgayLichHoc)
                {
                    var lichHocChiTiet = new LichHoc
                    {
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
                var xuLyListLichHoc = await _lichHocDependency.CheckByIdLopIdHocKyBlockIdMonAndNgayLichHoc(listLichHoc);
                var kqUpdateLichHoc = await _lichHocDependency.SuaLichHoc(xuLyListLichHoc);
                return Ok(kqUpdateLichHoc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost, Route("XoaLichHoc")]
        public async Task<IActionResult> XoaLichHoc(LichHocDTO lichHocChiTietDto)
        {
            try
            {
                List<LichHoc> listLichHoc = new List<LichHoc>();
                foreach (var ngay in lichHocChiTietDto.NgayLichHoc)
                {
                    var lichHocChiTiet = new LichHoc
                    {
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
                var xuLyListLichHoc = await _lichHocDependency.CheckByIdLopIdHocKyBlockIdMonAndNgayLichHoc(listLichHoc);
                var kqUpdateLichHoc = await _lichHocDependency.XoaLichHoc(xuLyListLichHoc);
                return Ok(kqUpdateLichHoc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

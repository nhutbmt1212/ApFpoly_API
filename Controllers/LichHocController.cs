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
        [HttpGet("LayLichHocUniqueMonHocTheoMaLop/{id}")]
        public async Task<IActionResult> LayLichHocUniqueMonHocTheoMaLop(string id)
        {
            var hocKyBlockHienTai = _hocKyBlockDependency.LayHocKyBlockHienTai();
            var lichHocs = await _lichHocDependency.LayLichHocUniqueMonHocTheoMaLop(id, hocKyBlockHienTai.MaHocKyBlock);
            //if (lichHocs == null || !lichHocs.Any())
            //{
            //    return NotFound();
            //}
            return Ok(lichHocs);
        }
        [HttpGet, Route("LayLichHoctheoIdMonHocIdLopVaIdHocKyBlock")]
        public async Task<IActionResult> LayLichHoctheoIdMonHocIdLopVaIdHocKyBlock(string MaLop, string MaMonHoc, string MaHocKyBlock)
        {
            var lichHoc = await _lichHocDependency.LayLichHoctheoIdMonHocIdLopVaIdHocKyBlock(MaLop, MaMonHoc, MaHocKyBlock);
            if (lichHoc != null)
            {
                return Ok(lichHoc);
            }
            return BadRequest();
        }


        [HttpGet, Route("LayLichHocTheoMaLopVaMaHocKyBlock")]
        public async Task<IActionResult> LayLichHocTheoMaLopVaMaHocKyBlock(string MaLop, string MaHocKyBlock)
        {
            var lichHocs = await _lichHocDependency.LayLichHocTheoMaLopVaMaHocKyBlock(MaLop, MaHocKyBlock);
            return Ok(lichHocs);
        }
        [HttpGet, Route("LayLichHocTheoMaGiangVien")]
        public async Task<IActionResult> LayLichHocTheoMaGiangVien(string MaLop, string MaHocKyBlock)
        {
            var lichHocs = await _lichHocDependency.LayLichHocTheoMaGiangVien(MaLop, MaHocKyBlock);
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
                    var kqLichHoc = await _lichHocDependency.LayLichHoctheoIdMonHocIdLopVaIdHocKyBlock(lichHocChiTietDto.MaLop, lichHocChiTietDto.MaMonHoc, lichHocChiTietDto.MaHocKyBlock);
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

        [HttpPost, Route("LayCacLichHocDaTrung")]
        public async Task<IActionResult> LayCacLichHocDaTrung(LichHocDTO lichHocDTO)
        {
            try
            {
                DateTime now = DateTime.Now; // Lấy ngày giờ hiện tại
                int gioBatDau = lichHocDTO.GioBatDau.Hour; // Lấy giờ bắt đầu từ lichHocDTO.GioBatDau
                int phutBatDau = lichHocDTO.GioBatDau.Minute; // Lấy phút bắt đầu từ lichHocDTO.GioBatDau
                int giayBatDau = lichHocDTO.GioBatDau.Second; // Lấy giây bắt đầu từ lichHocDTO.GioBatDau

                DateTime ThoiGianBatDau = new DateTime(now.Year, now.Month, now.Day, gioBatDau, phutBatDau, giayBatDau);




                var lichHocChiTiet = new LichHoc
                {

                    ThoiGianBatDau = ThoiGianBatDau,
                    MaLop = lichHocDTO.MaLop,
                    MaHocKyBlock = lichHocDTO.MaHocKyBlock,
                    MaPhong = lichHocDTO.MaPhong,
                    MaGiangVien = lichHocDTO.MaGiangVien,
                    MaMonHoc = lichHocDTO.MaMonHoc
                };
                var lichHocsValidate = await _lichHocDependency.LayCacLichHocDaTrung(lichHocChiTiet);
                return Ok(lichHocsValidate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost, Route("LayCacLichHocDaTrungTruMaLichTarget")]
        public async Task<IActionResult> LayCacLichHocDaTrungTruMaLichTarget(LichHocDTO lichHocDTO)
        {
            try
            {
                DateTime now = DateTime.Now; // Lấy ngày giờ hiện tại
                int gioBatDau = lichHocDTO.GioBatDau.Hour; // Lấy giờ bắt đầu từ lichHocDTO.GioBatDau
                int phutBatDau = lichHocDTO.GioBatDau.Minute; // Lấy phút bắt đầu từ lichHocDTO.GioBatDau
                int giayBatDau = lichHocDTO.GioBatDau.Second; // Lấy giây bắt đầu từ lichHocDTO.GioBatDau
                DateTime ThoiGianBatDau = new DateTime(now.Year, now.Month, now.Day, gioBatDau, phutBatDau, giayBatDau);
                var lichHocChiTiet = new LichHoc
                {

                    ThoiGianBatDau = ThoiGianBatDau,
                    MaLop = lichHocDTO.MaLop,
                    MaHocKyBlock = lichHocDTO.MaHocKyBlock,
                    MaPhong = lichHocDTO.MaPhong,
                    MaGiangVien = lichHocDTO.MaGiangVien,
                    MaMonHoc = lichHocDTO.MaMonHoc
                };
                var lichHocsValidate = await _lichHocDependency.LayCacLichHocDaTrungTruMaLichTarget(lichHocChiTiet);
                return Ok(lichHocsValidate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet, Route("ExportLichHoc")]
        public IActionResult ExportLichHoc()
        {
            var fileContents = _lichHocDependency.ExportLichHocToExcel();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "SinhVien.xlsx"
            );
        }

        [HttpPost,Route("XoaLichHocTheoMonHoc")]
        public async Task<IActionResult> XoaLichHocTheoMonHoc(List<LichHoc> lichHoc)
        {
            try
            {
                List<LichHoc> listLichHocCanXoa = new List<LichHoc>();
                foreach (var item in lichHoc)
                {
                    var lichHocs = await _lichHocDependency.LayLichHoctheoIdMonHocIdLopVaIdHocKyBlock(item.MaLop, item.MaMonHoc, item.MaHocKyBlock);
                    listLichHocCanXoa.AddRange(lichHocs);
                }

                var lichHocDaXoa = await _lichHocDependency.XoaLichHoc(listLichHocCanXoa);
                return Ok(lichHocDaXoa);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

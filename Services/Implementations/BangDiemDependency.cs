using ApFpoly_API.Data;
using ApFpoly_API.DTO;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApFpoly_API.Services.Implementations
{
    public class BangDiemDependency : IBangDiemDependency
    {
        private readonly DataContext _db;
        public BangDiemDependency(DataContext db)
        {
            _db = db;
        }

        public async Task<List<LopBangDiemDTO>> LayBangDiem()
        {
            // Lấy danh sách lịch học duy nhất cho mỗi lớp, giảng viên và môn học
            // Điều này giúp loại bỏ các bản ghi trùng lặp
            var lichHocUniqueLop = await _db.LichHoc
                .GroupBy(s => new { s.MaLop, s.MaGiangVien, s.MaMonHoc })
                .Select(s => s.First())
                .ToListAsync();

            // Tính sĩ số cho mỗi lớp, không tính các bản ghi đã bị xóa
            var siSoLop = await _db.LopHocChiTiet
                .Where(l => l.TinhTrang != "Đã xóa")
                .GroupBy(l => l.MaLop)
                .Select(g => new { MaLop = g.Key, SiSo = g.Count() })
                .ToListAsync();

            // Đếm số lượng nộp bài cho mỗi sinh viên, môn học và lớp
            // Cũng không tính các bản ghi đã bị xóa
            var soLuongNopBai = await _db.NopBai
                .Where(s => s.TinhTrang != "Đã xóa")
                .GroupBy(s => new { s.MaLop, s.MaMonHoc, s.MaSinhVien })
                .Select(g => new
                {
                    MaLop = g.Key.MaLop,
                    MaMonHoc = g.Key.MaMonHoc,
                    MaSinhVien = g.Key.MaSinhVien,
                    TongSoNop = g.Count(),
                    TinhTrang = g.FirstOrDefault().TinhTrang,
                })
                .ToListAsync();

            // Kết hợp các dữ liệu đã lấy để tạo danh sách bảng điểm cho mỗi lớp
            var bangDiem = (from lh in lichHocUniqueLop
                            join sl in siSoLop on lh.MaLop equals sl.MaLop into slGroup
                            from subSl in slGroup.DefaultIfEmpty()
                            join nb in soLuongNopBai on new { lh.MaLop, lh.MaMonHoc } equals new { nb.MaLop, nb.MaMonHoc } into nbGroup
                            from subNb in nbGroup.DefaultIfEmpty()
                            select new LopBangDiemDTO
                            {
                                MaLop = lh.MaLop,
                                LopHoc = _db.LopHoc.FirstOrDefault(l => l.MaLop == lh.MaLop), // Lấy thông tin lớp học từ bảng LopHoc
                                MaGiangVien = lh.MaGiangVien,
                                GiangVien = _db.GiangVien.FirstOrDefault(gv => gv.MaGiangVien == lh.MaGiangVien), // Lấy thông tin giảng viên từ bảng GiangVien
                                MaMonHoc = lh.MaMonHoc,
                                MonHoc = _db.MonHoc.FirstOrDefault(mh => mh.MaMonHoc == lh.MaMonHoc), // Lấy thông tin môn học từ bảng MonHoc
                                MaHocKyBlock = lh.MaHocKyBlock,
                                HocKyBlock = _db.HocKyBlock.FirstOrDefault(mh => mh.MaHocKyBlock == lh.MaHocKyBlock), // Lấy thông tin học kỳ/block từ bảng HocKyBlock
                                SiSo = subSl != null ? subSl.SiSo : 0, // Nếu không có thông tin thì sĩ số là 0
                                TongSoNop = subNb != null ? subNb.TongSoNop : 0, // Nếu không có thông tin thì tổng số nộp là 0
                                TinhTrang = subNb?.TinhTrang ?? "Đang đợi duyệt" // Sử dụng toán tử ?? để cung cấp giá trị mặc định khi không có thông tin
                            }).ToList();

            return bangDiem; // Trả về danh sách bảng điểm đã được tạo ra từ các
        }

        public async Task<List<BangDiem>> LayBangDiemTheoId(string MaLop, string MaMonHoc)
        {
            //var bangDiems = await _db.BangDiem.Where(s => s.MaLop == MaLop && s.MaMonHoc == MaMonHoc && s.TinhTrang != "Đã xóa")
            //    .ToListAsync();
            //return bangDiems;   
            var sinhVienTrongLop = await _db.LopHocChiTiet.Where(s => s.MaLop == MaLop && s.TinhTrang != "Đã xóa").ToListAsync();
            var layNhungSinhVienDaNopBai =  _db.NopBai.AsEnumerable().Join(sinhVienTrongLop,
                sv=>sv.MaSinhVien,
                nb=>nb.MaSinhVien,
                (sv,nb)=>new {SinhVien = sv,NopBai = nb})
                .Where(s=>s.NopBai.TinhTrang == "Đã nộp")
                .Select(x=>x.NopBai)
                .ToList();


            var s = "23123213231321'";
            return null;
        }

        public async Task<IEnumerable<BangDiem>> LayBangDiemTheoIdLop(string MaLop)
        {
            var bangDiems = await _db.BangDiem.Where(s => s.MaLop == MaLop).ToListAsync();
            return bangDiems;
        }

        public async Task<BangDiem> LayDiemTheoSinhVien(string MaLop, string MaSinhVien, string MaMonHoc)
        {
            var bangDiem = await _db.BangDiem.FirstOrDefaultAsync(s => s.MaLop == MaLop && s.MaSinhVien == MaSinhVien && s.MaMonHoc == MaMonHoc);
            if (bangDiem != null)
            {
                return bangDiem;
            }
            return null;
        }

        public async Task<BangDiem> SuaDiemChoSinhVien(string MaLop, string MaSinhVien, string MaMonHoc, double Diem)
        {
            var bangDiem = await _db.BangDiem.FirstOrDefaultAsync(s => s.MaLop == MaLop && s.MaSinhVien == MaSinhVien && s.MaMonHoc == MaMonHoc);
            if (bangDiem != null)
            {
                bangDiem.Diem = Diem;
                _db.BangDiem.Update(bangDiem);
                await _db.SaveChangesAsync();
                return bangDiem;
            }
            return null;
        }

        public async Task<BangDiem> ThemBangDiem(BangDiem bangDiem)
        {
            try
            {
                _db.BangDiem.Add(bangDiem);
                _db.SaveChanges();
                return bangDiem;
            }
            catch
            (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

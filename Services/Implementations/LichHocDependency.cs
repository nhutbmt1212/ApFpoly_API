using ApFpoly_API.Data;
using ApFpoly_API.DTO;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace ApFpoly_API.Services.Implementations
{
    public class LichHocDependency : ILichHocDependency
    {
        private readonly DataContext _dbContext;

        public LichHocDependency(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<LichHoc> LayDanhSachLichHoc()
        {
            return _dbContext.LichHoc.Include(x => x.GiangVien).Include(x => x.LopHoc).Include(x => x.MonHoc).Include(x => x.PhongHoc).Where(s => s.TinhTrang != "Đã xóa" && s.TinhTrang != "Ngưng hoạt động").ToList();
        }

        public LichHoc LayLichHocTheoId(string id)
        {
            return _dbContext.LichHoc.FirstOrDefault(x => x.MaLichHoc == id);
        }

        public List<LichHoc> LayLichHocTheoMaHocKyBlockVaLop(HocKyBlockVaLopDTO hocKyBlockVaLopDTO)
        {
            return _dbContext.LichHoc.Include(x => x.GiangVien).Include(x => x.LopHoc).Include(x => x.MonHoc).Include(x => x.PhongHoc).Where(x => x.MaHocKyBlock == hocKyBlockVaLopDTO.MaHocKyBlock && x.MaLop == hocKyBlockVaLopDTO.MaLop).ToList();
        }
        public List<LichHoc> LayLichHocTheoMaGiangVienVaMaHocKyBlock(string maGiangVien, string maHocKyBlock)
        {
            var lichhoc = _dbContext.LichHoc.Include(x => x.GiangVien).Include(x => x.LopHoc).Include(x => x.MonHoc).Include(x => x.PhongHoc)
                .Where(x => x.MaHocKyBlock == maHocKyBlock && x.MaGiangVien == maGiangVien)
                .ToList();
            lichhoc = lichhoc.GroupBy(lh => new { lh.MaMonHoc, lh.MaLop })
                    .Select(g => 
                    {
                        var lichHoc = g.First();
                        lichHoc.ThoiGianBatDau = g.Min(lh => lh.ThoiGianBatDau);
                        lichHoc.ThoiGianKetThuc = g.Max(lh => lh.ThoiGianKetThuc);
                        return lichHoc;
                    })
                    .ToList();



            return lichhoc;
        }

        public List<LichHoc> LayLichHocTheoMaSinhVienVaMaHocKyBlock(string maSinhVien, string maHocKyBlock)
        {
            var maLopList = _dbContext.LopHocChiTiet.Where(lhc => lhc.MaSinhVien == maSinhVien && lhc.TinhTrang != "Đã xóa").Select(lhc => lhc.MaLop).ToList();

            var lichHoc = _dbContext.LichHoc.Include(x => x.GiangVien).Include(x => x.LopHoc).Include(x => x.MonHoc).Include(x => x.PhongHoc)
                .Where(x => x.MaHocKyBlock == maHocKyBlock && maLopList.Contains(x.MaLop))
                .ToList();

            lichHoc = lichHoc.GroupBy(lh => new { lh.MaMonHoc, lh.MaLop })

                     .Select(g => 
                     {

                         var lichHoc = g.First();
                         lichHoc.ThoiGianBatDau = g.Min(lh => lh.ThoiGianBatDau);
                         lichHoc.ThoiGianKetThuc = g.Max(lh => lh.ThoiGianKetThuc);
                         return lichHoc;

                     })

                     .ToList();

            return lichHoc;
        }




        public List<LichHoc> ThemLichHoc(List<LichHoc> lichHoc)
        {
            _dbContext.LichHoc.AddRange(lichHoc);
            _dbContext.SaveChanges();
            return lichHoc;
        }
        public async Task<IEnumerable<LichHoc>> LayLichHocUniqueMonHocTheoMaLop(string MaLop, string MaHocKyBlock)
        {
            // Giả sử _dbContext là một instance của DbContext của bạn
            var lichHocs = await _dbContext.LichHoc
                .Include(x => x.LopHoc)
                .Include(x => x.MonHoc)
                .Include(x => x.PhongHoc)
                .Include(x => x.HocKyBlock)
.Include(x => x.GiangVien)
        .Where(lh => lh.MaLop == MaLop && lh.MaHocKyBlock == MaHocKyBlock)
        .GroupBy(lh => lh.MaMonHoc)
        .Select(g => g.First())


        .ToListAsync();

            return lichHocs;
        }



        public LichHoc XoaLichHoc(string id)
        {
            var lichHoc = _dbContext.LichHoc.FirstOrDefault(x => x.MaLichHoc == id);
            if (lichHoc != null)
            {
                _dbContext.LichHoc.Remove(lichHoc);
                _dbContext.SaveChanges();
            }
            return lichHoc;
        }

        public async Task<IEnumerable<LichHoc>> LayLichHocTheoMaLopVaMaHocKyBlock(string MaLop, string MaHocKyBlock)
        {
            var monHocs = await _dbContext.LichHoc
                .Where(s => s.MaLop == MaLop && s.MaHocKyBlock == MaHocKyBlock)
                .Include(x => x.GiangVien)
                .Include(x => x.LopHoc)
                .Include(x => x.MonHoc)
                .Include(x => x.PhongHoc)
                .Include(x => x.HocKyBlock)
                .ToListAsync();
            return monHocs;
        }

        public async Task<IEnumerable<LichHoc>> LayLichHocTheoIdLop(string id)
        {
            var lichHocs = await _dbContext.LichHoc
                .Where(s => s.MaLop == id)
                  .Include(x => x.GiangVien)
                .Include(x => x.LopHoc)
                .Include(x => x.MonHoc)
                .Include(x => x.PhongHoc)
                .Include(x => x.HocKyBlock)
                .ToListAsync();
            return lichHocs;
        }

        public async Task<IEnumerable<LichHoc>> SuaLichHoc(List<LichHoc> lichHoc)
        {

            _dbContext.LichHoc.UpdateRange(lichHoc);
           await _dbContext.SaveChangesAsync();
            return lichHoc;
        }


        public async Task<List<LichHoc>> CheckByIdLopIdHocKyBlockIdMonAndNgayLichHoc(List<LichHoc> lichHoc)
        {
            List<LichHoc> validLichHoc = new List<LichHoc>();

            try
            {
                foreach (var lh in lichHoc)
                {
                    var lhThoiGianBatDau = ConvertDatetimeToDateOnly(lh.ThoiGianBatDau);
                    var existLichHocList = await _dbContext.LichHoc.Where(s => s.MaLop == lh.MaLop && s.MaMonHoc == lh.MaMonHoc
                    && s.MaHocKyBlock == lh.MaHocKyBlock
                    ).ToListAsync();

                    foreach (var existLichHoc in existLichHocList)
                    {
                        var existThoiGianBatDau = ConvertDatetimeToDateOnly(existLichHoc.ThoiGianBatDau);
                        if (existThoiGianBatDau == lhThoiGianBatDau)
                        {
                            // Thêm vào danh sách nếu thời gian bắt đầu trùng khớp
                            existLichHoc.ThoiGianBatDau = lh.ThoiGianBatDau;
                            existLichHoc.ThoiGianKetThuc = lh.ThoiGianKetThuc;
                            existLichHoc.TinhTrang = lh.TinhTrang;
                            existLichHoc.MaLop = lh.MaLop;
                            existLichHoc.MaGiangVien = lh.MaGiangVien;
                            existLichHoc.MaHocKyBlock = lh.MaHocKyBlock;
                            existLichHoc.MaMonHoc = lh.MaMonHoc;
                            existLichHoc.MaPhong = lh.MaPhong;

                           
                            validLichHoc.Add(existLichHoc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ ở đây
                throw new Exception(ex.Message);
            }

            return validLichHoc;
        }


        public DateOnly ConvertDatetimeToDateOnly(DateTime paramDatetime)
        {
            return DateOnly.FromDateTime(paramDatetime);
        }


        public async Task<IEnumerable<LichHoc>> XoaLichHoc(List<LichHoc> lichHoc)
        {
            _dbContext.LichHoc.RemoveRange(lichHoc);
            _dbContext.SaveChangesAsync();
            return lichHoc;
        }

        public async Task<IEnumerable<LichHoc>> LayLichHoctheoIdMonHocIdLopVaIdHocKyBlock(string MaLop, string MaMonHoc, string MaHocKyBlock)
        {
            var lichHocs = await _dbContext.LichHoc
                .Where(s => s.MaLop == MaLop && s.MaMonHoc == MaMonHoc && s.MaHocKyBlock == MaHocKyBlock)
                .Include(x => x.GiangVien)
                .Include(x => x.LopHoc)
                .Include(x => x.MonHoc)
                .Include(x => x.PhongHoc)
                .Include(x => x.HocKyBlock).ToListAsync();
            return lichHocs;
        }

        public async Task<IEnumerable<LichHoc>> LayLichHocTheoMaGiangVien(string MaGiangVien, string MaHocKyBlock)
        {
            var lichHocs = await _dbContext.LichHoc
                .Where(s => s.MaGiangVien == MaGiangVien && s.MaHocKyBlock == MaHocKyBlock)
                 .Include(x => x.GiangVien)
                .Include(x => x.LopHoc)
                .Include(x => x.MonHoc)
                .Include(x => x.PhongHoc)
                .Include(x => x.HocKyBlock).ToListAsync();
            return lichHocs;
        }

        public async Task<IEnumerable<LichHoc>> LayCacLichHocDaTrung(LichHoc lichHoc)
        {
            TimeOnly thoiGianBatDauConverted = TimeOnly.FromDateTime(lichHoc.ThoiGianBatDau);
            var lichHocTrungs = await _dbContext.LichHoc
                .Where(s=> s.MaHocKyBlock == lichHoc.MaHocKyBlock && s.MaPhong == lichHoc.MaPhong)
                .ToListAsync(); // Chuyển đổi kết quả query thành list trước khi so sánh thời gian

            lichHocTrungs = lichHocTrungs
                .Where(s => TimeOnly.FromDateTime(s.ThoiGianBatDau) == thoiGianBatDauConverted) // So sánh thời gian sau khi đã chuyển đổi kết quả query thành list
                .ToList();

            return lichHocTrungs;
        }
        

        public async Task<IEnumerable<LichHoc>> LayCacLichHocDaTrungTruMaLichTarget(LichHoc lichHoc)
        {
                TimeOnly thoiGianBatDauConverted = TimeOnly.FromDateTime(lichHoc.ThoiGianBatDau);

            var lichHocs = await _dbContext.LichHoc
                .Where(s => (s.MaLop != lichHoc.MaLop
            || s.MaMonHoc != lichHoc.MaMonHoc)
            && s.MaHocKyBlock == lichHoc.MaHocKyBlock && s.MaPhong == lichHoc.MaPhong
            ).ToListAsync();
            lichHocs = lichHocs
              .Where(s => TimeOnly.FromDateTime(s.ThoiGianBatDau) == thoiGianBatDauConverted) // So sánh thời gian sau khi đã chuyển đổi kết quả query thành list
              .ToList();

            return lichHocs;
        }
        public byte[] ExportLichHocToExcel()
        {
            var lichHocs = _dbContext.LichHoc
                .Include(x => x.GiangVien)
                .Include(x => x.LopHoc)
                .Include(x => x.MonHoc)
                .Include(x => x.PhongHoc)
                .Include(x => x.HocKyBlock)
                .ToList();
            if (lichHocs == null) return [];
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("LichHoc");

                // Sort and group data
                var sortedLichHocs = lichHocs.OrderBy(lh => lh.ThoiGianBatDau)
                    .GroupBy(lh => new { lh.MaLop, lh.MaHocKyBlock, lh.MaPhong, lh.MaGiangVien, lh.MaMonHoc })
                    .ToList();
                int currentRow = 1;
                // Add data
                foreach (var group in sortedLichHocs)
                {
                    // Add title for each group
                    // Add title for each group
                    worksheet.Cells[currentRow, 1].Value = $"Lịch học lớp {group.Key.MaLop}";
                    worksheet.Cells[currentRow, 1, currentRow, 9].Merge = true; // Merge 9 columns
                    worksheet.Cells[currentRow, 1, currentRow, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Center text
                    worksheet.Cells[currentRow, 1, currentRow, 9].Style.Font.Size = 14; // Increase font size
                    worksheet.Cells[currentRow, 1, currentRow, 9].Style.Font.Bold = true; // Make title bold
                    worksheet.Cells[currentRow, 1, currentRow, 9].Style.Border.BorderAround(ExcelBorderStyle.Medium); // Add border

                    worksheet.Cells[currentRow, 1, currentRow, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[currentRow, 1, currentRow, 9].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(219, 219, 219));
                    currentRow++;


                    // Add header
                    worksheet.Cells[currentRow, 1].Value = "Mã Lịch Học";
                    worksheet.Cells[currentRow, 2].Value = "Tên Lớp";
                    worksheet.Cells[currentRow, 3].Value = "Tên Học Kỳ Và Block";
                    worksheet.Cells[currentRow, 4].Value = "Tên Phòng";
                    worksheet.Cells[currentRow, 5].Value = "Tên Giảng Viên";
                    worksheet.Cells[currentRow, 6].Value = "Tên Môn Học";
                    worksheet.Cells[currentRow, 7].Value = "Thời Gian Bắt Đầu";
                    worksheet.Cells[currentRow, 8].Value = "Thời Gian Kết Thúc";
                    worksheet.Cells[currentRow, 9].Value = "Tình Trạng";
                    worksheet.Cells[currentRow, 1, currentRow, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    currentRow++;

                    foreach (var lichHoc in group)
                    {
                        worksheet.Cells[currentRow, 1].Value = lichHoc.MaLichHoc;
                        worksheet.Cells[currentRow, 2].Value = lichHoc?.LopHoc?.TenLop;
                        worksheet.Cells[currentRow, 3].Value = lichHoc?.HocKyBlock.TenHocKy + " - "+ lichHoc?.HocKyBlock.TenBlock;
                        worksheet.Cells[currentRow, 4].Value = lichHoc?.PhongHoc?.TenPhong;
                        worksheet.Cells[currentRow, 5].Value = lichHoc?.GiangVien?.TenGiangVien;
                        worksheet.Cells[currentRow, 6].Value = lichHoc?.MonHoc?.TenMonHoc;
                        worksheet.Cells[currentRow, 7].Value = lichHoc?.ThoiGianBatDau;
                        worksheet.Cells[currentRow, 7].Style.Numberformat.Format = "dd/MM/yyyy hh:mm:ss";
                        worksheet.Cells[currentRow, 8].Value = lichHoc?.ThoiGianKetThuc;
                        worksheet.Cells[currentRow, 8].Style.Numberformat.Format = "dd/MM/yyyy hh:mm:ss";
                        worksheet.Cells[currentRow, 9].Value = lichHoc?.TinhTrang;
                        worksheet.Cells[currentRow, 1, currentRow, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin); // Add border to each row
                      DateTime now = DateTime.Now;
                        DateTime ngayBatDau = new DateTime(lichHoc.ThoiGianBatDau.Year, lichHoc.ThoiGianBatDau.Month, lichHoc.ThoiGianBatDau.Day) ;
                        if (now.Date == ngayBatDau.Date)
                        {
                            worksheet.Cells[currentRow, 1, currentRow, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;

                            worksheet.Cells[currentRow, 1, currentRow, 9].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 129, 0));

                        }
                        currentRow++;
                    }

                    // Add an empty row between groups
                    currentRow++;
                }
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();


                return package.GetAsByteArray();
            }
        }

    }
}

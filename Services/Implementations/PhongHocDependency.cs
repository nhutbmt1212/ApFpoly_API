using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;
using System.Text;

namespace ApFpoly_API.Services.Implementations
{
    public class PhongHocDependency : IPhongHocDependency
    {
        DataContext _db;
        public PhongHocDependency(DataContext db)
        {
            _db = db;
        }
        public List<PhongHoc> LayPhongHoc()
        {
            var getPhongHoc = _db.PhongHoc.Where(s => s.TinhTrang != "Đã xóa" ).ToList();
            return getPhongHoc;
        }

        public PhongHoc LayPhongHocTheoMaPhongHoc(string MaPhongHoc)
        {
            var getPhongHocTheoId = _db.PhongHoc.FirstOrDefault(s => s.MaPhong == MaPhongHoc);
            return getPhongHocTheoId;
        }
        public async Task<IEnumerable<PhongHoc>> SearchingPhongHoc(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = RemoveDiacritics(searchString).ToLower();
                var phongHocs = _db.PhongHoc.AsEnumerable()
                               .Where(s => RemoveDiacritics(s.MaPhong.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TenPhong.ToLower()).Contains(searchString) || s.TinhTrang != "Đã xóa" 
                                     ).Take(5);
                return phongHocs.ToList();
            }
            else
            {
                return await _db.PhongHoc.ToListAsync();
            }
        }


        public static string RemoveDiacritics(string text)
        {
            var normalized = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    if (c == 'đ') stringBuilder.Append('d');
                    else if (c == 'Đ') stringBuilder.Append('D');
                    else stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        public async Task<PhongHoc> SuaPhongHoc(PhongHoc PhongHoc)
        {
            try
            {
                var existPhongHoc = await _db.PhongHoc.FirstOrDefaultAsync(s => s.MaPhong == PhongHoc.MaPhong);
                if (existPhongHoc == null)
                {
                    throw new Exception("Không có phòng học này");
                }
                _db.Entry(existPhongHoc).CurrentValues.SetValues(PhongHoc);
                await _db.SaveChangesAsync();
                return PhongHoc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PhongHoc ThemPhongHoc(PhongHoc PhongHoc)
        {
            try
            {
                _db.PhongHoc.Add(PhongHoc);
                _db.SaveChanges();
                return PhongHoc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PhongHoc> XoaPhongHoc(string MaPhongHoc)
        {
            try
            {
                var existPhongHoc = await _db.PhongHoc.FirstOrDefaultAsync(s => s.MaPhong == MaPhongHoc);
                if (existPhongHoc == null)
                {
                    throw new Exception("Mã phòng học không tồn tại");
                }
                existPhongHoc.TinhTrang = "Đã xóa";
                _db.PhongHoc.Update(existPhongHoc);
                _db.SaveChanges();
                return existPhongHoc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int SoLuongPhongHoc()
        {
            return _db.PhongHoc.Count();
        }

        public IEnumerable<PhongHoc> GetPhongHoc(int page, int pageSize)
        {
            if (page < 1)
            {
                page = 1;
            }

            var totalCount = SoLuongPhongHoc();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var productPerPage = _db.PhongHoc
                .Skip((page - 1) * pageSize).Where(s => s.TinhTrang != "Đã xóa")
                .Take(pageSize).OrderByDescending(x => x.NgayTao).ToList();
            return productPerPage;
        }

        public async Task<IEnumerable<PhongHoc>> SearchingPhongHocForTimKiem(string searchString, int limitItem)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = RemoveDiacritics(searchString).ToLower();
                var students = _db.PhongHoc.AsEnumerable()
                               .Where(s => RemoveDiacritics(s.MaPhong.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TenPhong.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.SucChua.ToString()).Contains(searchString)
                                        || RemoveDiacritics(s.LoaiPhong.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TinhTrang.ToLower()).Contains(searchString))
                               .Take(limitItem)
                               .ToList()
                               ;
                return students;
            }
            else
            {
                return null;
            }
        }
        public byte[] ExportPhongHocToExcel()
        {
            var phongHocs = _db.PhongHoc.ToList();
            if (phongHocs == null) return [];
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("PhongHoc");
                // Add header
                worksheet.Cells[1, 1].Value = "Mã Phòng";
                worksheet.Cells[1, 2].Value = "Tên Phòng";
                worksheet.Cells[1, 3].Value = "Ngày Tạo";
                worksheet.Cells[1, 4].Value = "Loại Phòng";
                worksheet.Cells[1, 5].Value = "Sức Chứa";
                worksheet.Cells[1, 6].Value = "Tình Trạng";

                // Add data
                for (int i = 0; i < phongHocs.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = phongHocs[i].MaPhong;
                    worksheet.Cells[i + 2, 2].Value = phongHocs[i].TenPhong;
                    worksheet.Cells[i + 2, 3].Value = phongHocs[i].NgayTao;
                    worksheet.Cells[i + 2, 3].Style.Numberformat.Format = "dd/MM/yyyy hh:mm:ss";
                    worksheet.Cells[i + 2, 4].Value = phongHocs[i].LoaiPhong;
                    worksheet.Cells[i + 2, 5].Value = phongHocs[i].SucChua;
                    worksheet.Cells[i + 2, 6].Value = phongHocs[i].TinhTrang;
                }
                return package.GetAsByteArray();
            }
        }
    }
}

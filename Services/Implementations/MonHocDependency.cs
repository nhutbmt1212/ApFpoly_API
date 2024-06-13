using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;
using System.Text;

namespace ApFpoly_API.Services.Implementations
{

    public class MonHocDependency : IMonHocDependency
    {
        DataContext _db;
        public MonHocDependency(DataContext db)
        {
            _db = db;
        }

        public List<MonHoc> LayMonHoc()
        {
            var getMonHoc = _db.MonHoc.Where(s => s.TinhTrang != "Đã xóa").ToList();
            return getMonHoc;
        }

        public MonHoc LayMonHocTheoMaMonHoc(string MaMonHoc)
        {
            var getMonHocTheoId = _db.MonHoc.FirstOrDefault(s => s.MaMonHoc == MaMonHoc);
            return getMonHocTheoId;
        }
        public async Task<IEnumerable<MonHoc>> SearchingMonHoc(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = RemoveDiacritics(searchString).ToLower();
                var monHocs = _db.MonHoc.AsEnumerable()
                               .Where(s => RemoveDiacritics(s.MaMonHoc.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TenMonHoc.ToLower()).Contains(searchString) || s.TinhTrang != "Đã xóa"
                                       ).Take(5);
                return monHocs.ToList();
            }
            else
            {
                return await _db.MonHoc.ToListAsync();
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

        public async Task<MonHoc> SuaMonHoc(MonHoc monhoc)
        {
            try
            {
                var existMonHoc = await _db.MonHoc.FirstOrDefaultAsync(s => s.MaMonHoc == monhoc.MaMonHoc);
                if (existMonHoc == null)
                {
                    throw new Exception("Không có sinh viên này");
                }
                _db.Entry(existMonHoc).CurrentValues.SetValues(monhoc);
                await _db.SaveChangesAsync();
                return monhoc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MonHoc ThemMonHoc(MonHoc monhoc)
        {
            try
            {
                _db.MonHoc.Add(monhoc);
                _db.SaveChanges();
                return monhoc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MonHoc> XoaMonHoc(string MaMonHoc)
        {
            try
            {
                var existMonHoc = await _db.MonHoc.FirstOrDefaultAsync(s => s.MaMonHoc == MaMonHoc);
                if (existMonHoc == null)
                {
                    throw new Exception("Mã nhân viên không tồn tại");
                }
                existMonHoc.TinhTrang = "Đã xóa";
                _db.MonHoc.Update(existMonHoc);
                _db.SaveChanges();
                return existMonHoc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int SoLuongMonHoc()
        {
            var monHocs = _db.MonHoc.Count();
            return monHocs;
        }

        public IEnumerable<MonHoc> GetMonHoc(int page, int pageSize)
        {
            {
                if (page < 1)
                {
                    page = 1;
                }

                var totalCount = SoLuongMonHoc();
                var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
                var productPerPage = _db.MonHoc
                    .Skip((page - 1) * pageSize).Where(s => s.TinhTrang != "Đã xóa")
                    .Take(pageSize).OrderByDescending(x => x.NgayTao).ToList();
                return productPerPage;
            }
        }
        public async Task<IEnumerable<MonHoc>> SearchingMonHocForTimKiem(string searchString, int limitItem)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = RemoveDiacritics(searchString).ToLower();
                var students = _db.MonHoc.AsEnumerable()
                               .Where(s => RemoveDiacritics(s.MaMonHoc.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TenMonHoc.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.SoBuoi.ToString()).Contains(searchString)
                                        //|| RemoveDiacritics(s.TinChi.ToString()).Contains(searchString)
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
        public byte[] ExportMonHocToExcel()
        {
            var monHocs = _db.MonHoc.ToList();
            if (monHocs == null) return [];
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("MonHoc");
                // Add header
                worksheet.Cells[1, 1].Value = "Mã Môn Học";
                worksheet.Cells[1, 2].Value = "Tên Môn Học";
                worksheet.Cells[1, 3].Value = "Ngày Tạo";
                worksheet.Cells[1, 4].Value = "Tín Chỉ";
                worksheet.Cells[1, 5].Value = "Số Buổi";
                worksheet.Cells[1, 6].Value = "Nội Dung Môn Học";
                worksheet.Cells[1, 7].Value = "Tài Liệu";
                worksheet.Cells[1, 8].Value = "Tình Trạng";

                // Add data
                for (int i = 0; i < monHocs.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = monHocs[i].MaMonHoc;
                    worksheet.Cells[i + 2, 2].Value = monHocs[i].TenMonHoc;
                    worksheet.Cells[i + 2, 3].Value = monHocs[i].NgayTao;
                    worksheet.Cells[i + 2, 3].Style.Numberformat.Format = "dd/MM/yyyy hh:mm:ss";
                    worksheet.Cells[i + 2, 4].Value = monHocs[i].TinChi;
                    worksheet.Cells[i + 2, 5].Value = monHocs[i].SoBuoi;
                    worksheet.Cells[i + 2, 6].Value = monHocs[i].NoiDungMonHoc;
                    worksheet.Cells[i + 2, 7].Value = monHocs[i].TaiLieu;
                    worksheet.Cells[i + 2, 8].Value = monHocs[i].TinhTrang;
                }
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                return package.GetAsByteArray();
            }
        }
    }
}


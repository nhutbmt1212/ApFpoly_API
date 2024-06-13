using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;
using System.Text;

namespace ApFpoly_API.Services.Implementations
{
    public class GiangVienDependency : IGiangVienDependency
    {
        DataContext _db;
        public GiangVienDependency(DataContext db)
        {
            _db = db;
        }
        public List<GiangVien> LayGiangVien()
        {
            var getGiangVien = _db.GiangVien.Where(s=>s.TinhTrang != "Đã xóa").ToList();
            return getGiangVien;
        }

        public GiangVien LayGiangVienTheoMaGiangVien(string MaGiangVien)
        {
            var getGiangVienTheoId = _db.GiangVien.FirstOrDefault(s => s.MaGiangVien == MaGiangVien);
            return getGiangVienTheoId;
        }
        public async Task<IEnumerable<GiangVien>> SearchingGiangVien(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = RemoveDiacritics(searchString).ToLower();
                var giangViens = _db.GiangVien.AsEnumerable()
                               .Where(s => RemoveDiacritics(s.MaGiangVien.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TenGiangVien.ToLower()).Contains(searchString) || s.TinhTrang != "Đã xóa" 
                                       ).Take(5);
                return giangViens.ToList();
            }
            else
            {
                return await _db.GiangVien.ToListAsync();
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

        public int SoLuongGiangVien()
        {
            return _db.GiangVien.Count();
        }

        public async Task<GiangVien> SuaGiangVien(GiangVien giangVien)
        {
            try
            {
                var existGiangVien = await _db.GiangVien.FirstOrDefaultAsync(s => s.MaGiangVien == giangVien.MaGiangVien);
                if (existGiangVien == null)
                {
                    throw new Exception("Không có giảng viên này");
                }
                _db.Entry(existGiangVien).CurrentValues.SetValues(giangVien);
                await _db.SaveChangesAsync();
                return giangVien;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GiangVien ThemGiangVien(GiangVien giangVien)
        {
            try
            {
                _db.GiangVien.Add(giangVien);
                _db.SaveChanges();
                return giangVien;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GiangVien> XoaGiangVien(string MaGiangVien)
        {
            try
            {
                var existGiangVien = await _db.GiangVien.FirstOrDefaultAsync(s => s.MaGiangVien == MaGiangVien);
                if (existGiangVien == null)
                {
                    throw new Exception("Mã giảng viên không tồn tại");
                }
                existGiangVien.TinhTrang = "Đã xóa";
                _db.GiangVien.Update(existGiangVien);
                _db.SaveChanges();
                return existGiangVien;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GiangVien LayGiangVienTheoEmail(string Email)
        {
            var giangVien = _db.GiangVien.FirstOrDefault(s => s.Email == Email);
            return giangVien;
        }

        public async Task<IEnumerable<GiangVien>> SearchingGiangVienForTimKiem(string searchString, int limitItem)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = RemoveDiacritics(searchString).ToLower();
                var giangVien = _db.GiangVien.AsEnumerable()
                               .Where(s => RemoveDiacritics(s.MaGiangVien.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.CCCD.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.SoDienThoai.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.Email.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TenGiangVien.ToLower()).Contains(searchString))
                               .Take(limitItem)
                               .ToList()
                               ;
                return giangVien;
            }
            else
            {
                return null;
            }
        }



        public static string RemoveDiacriticsTimKiem(string text)
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

        public IEnumerable<GiangVien> GetGiangVien(int page, int pageSize)
        {
            if (page < 1)
            {
                page = 1;
            }

            var totalCount = SoLuongGiangVien();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var giangVienPerPage = _db.GiangVien
                .Skip((page - 1) * pageSize).Where(s => s.TinhTrang != "Đã xóa")
                .Take(pageSize).OrderByDescending(x => x.NgayThem).ToList();
            return giangVienPerPage;
        }
        public byte[] ExportGiangVienToExcel()
        {
            var giangViens = _db.GiangVien.ToList();
            if (giangViens == null) return[];
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("GiangVien");
                // Add header
                worksheet.Cells[1, 1].Value = "Mã Giảng Viên";
                worksheet.Cells[1, 2].Value = "Tên Giảng Viên";
                worksheet.Cells[1, 3].Value = "Giới Tính";
                worksheet.Cells[1, 4].Value = "Số Điện Thoại";
                worksheet.Cells[1, 5].Value = "Ngày Sinh";
                worksheet.Cells[1, 6].Value = "Dân Tộc";
                worksheet.Cells[1, 7].Value = "Ngành";
                worksheet.Cells[1, 8].Value = "Email";
                worksheet.Cells[1, 9].Value = "CCCD";
                worksheet.Cells[1, 10].Value = "Ngày Vào Làm";
                worksheet.Cells[1, 11].Value = "Địa Chỉ";
                worksheet.Cells[1, 12].Value = "Chức Vụ";
                worksheet.Cells[1, 13].Value = "Ngày Thêm";
                worksheet.Cells[1, 14].Value = "Tình Trạng";
                worksheet.Cells[1, 15].Value = "Ảnh Giảng Viên";

                // Add data
                for (int i = 0; i < giangViens.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = giangViens[i].MaGiangVien;
                    worksheet.Cells[i + 2, 2].Value = giangViens[i].TenGiangVien;
                    worksheet.Cells[i + 2, 3].Value = giangViens[i].GioiTinh;
                    worksheet.Cells[i + 2, 4].Value = giangViens[i].SoDienThoai;
                    worksheet.Cells[i + 2, 5].Value = giangViens[i].NgaySinh;
                    worksheet.Cells[i + 2, 5].Style.Numberformat.Format = "dd/MM/yyyy hh:mm:ss";
                    worksheet.Cells[i + 2, 6].Value = giangViens[i].DanToc;
                    worksheet.Cells[i + 2, 7].Value = giangViens[i].Nganh;
                    worksheet.Cells[i + 2, 8].Value = giangViens[i].Email;
                    worksheet.Cells[i + 2, 9].Value = giangViens[i].CCCD;
                    worksheet.Cells[i + 2, 10].Value = giangViens[i].NgayVaoLam;
                    worksheet.Cells[i + 2, 10].Style.Numberformat.Format = "dd/MM/yyyy hh:mm:ss";
                    worksheet.Cells[i + 2, 11].Value = giangViens[i].DiaChi;
                    worksheet.Cells[i + 2, 12].Value = giangViens[i].ChucVu;
                    worksheet.Cells[i + 2, 13].Value = giangViens[i].NgayThem;
                    worksheet.Cells[i + 2, 13].Style.Numberformat.Format = "dd/MM/yyyy hh:mm:ss";
                    worksheet.Cells[i + 2, 14].Value = giangViens[i].TinhTrang;
                    worksheet.Cells[i + 2, 15].Value = giangViens[i].AnhGiangVien;
                }
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                return package.GetAsByteArray();
            }
        }
    }
}


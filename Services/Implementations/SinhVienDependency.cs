using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;
using System.Text;

namespace ApFpoly_API.Services.Implementations
{
    public class SinhVienDependency : ISinhVienDependency
    {
        DataContext _db;
        public SinhVienDependency(DataContext db)
        {
            _db = db;
        }

        public IEnumerable<SinhVien> GetSinhVien(int page, int pageSize)
        {
            if (page < 1)
            {
                page = 1;
            }

            var totalCount = SoLuongSinhVien();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var productPerPage = _db.SinhVien
                .Skip((page - 1) * pageSize).Where(s => s.TinhTrang != "Đã xóa")
                .Take(pageSize).OrderByDescending(x => x.NgayThem).ToList();
            return productPerPage;
        }



        public List<SinhVien> LaySinhVien()
        {
            var getSinhVien = _db.SinhVien.Where(s => s.TinhTrang != "Đã xóa" ).ToList();
            return getSinhVien;
        }

        public SinhVien LaySinhVienTheoMaSinhVien(string MaSinhVien)
        {
            var getSinhVienTheoId = _db.SinhVien.FirstOrDefault(s => s.MaSinhVien == MaSinhVien);
            return getSinhVienTheoId;
        }

        public async Task<IEnumerable<SinhVien>> SearchingSinhVien(string searchString, int limitItem)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = RemoveDiacritics(searchString).ToLower();
                var students = _db.SinhVien.AsEnumerable()
                               .Where(s => RemoveDiacritics(s.MaSinhVien.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.CCCD.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.SoDienThoai.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.Email.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TenSinhVien.ToLower()).Contains(searchString))
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

        public int SoLuongSinhVien()
        {
            return _db.SinhVien.Count();
        }

        public async Task<SinhVien> SuaSinhVien(SinhVien sinhvien)
        {
            try
            {
                var existSinhVien = await _db.SinhVien.FirstOrDefaultAsync(s => s.MaSinhVien == sinhvien.MaSinhVien);
                if (existSinhVien == null)
                {
                    throw new Exception("Không có sinh viên này");
                }
                _db.Entry(existSinhVien).CurrentValues.SetValues(sinhvien);
                await _db.SaveChangesAsync();
                return sinhvien;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SinhVien ThemSinhVien(SinhVien SinhVien)
        {
            try
            {
                _db.SinhVien.Add(SinhVien);
                _db.SaveChanges();
                return SinhVien;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SinhVien> XoaSinhVien(string MaSinhVien)
        {
            try
            {
                var existSinhVien = await _db.SinhVien.FirstOrDefaultAsync(s => s.MaSinhVien == MaSinhVien);
                if (existSinhVien == null)
                {
                    throw new Exception("Mã nhân viên không tồn tại");
                }
                existSinhVien.TinhTrang = "Đã xóa";
                _db.SinhVien.Update(existSinhVien);
                _db.SaveChanges();
                return existSinhVien;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SinhVien LaySinhVienTheoEmail(string Email)
        {
            var sinhVien = _db.SinhVien.FirstOrDefault(s => s.Email == Email);
            return sinhVien;
        }

        public byte[] ExportSinhVienToExcel()
        {
            var sinhViens = _db.SinhVien.ToList();
            if (sinhViens == null) return[]; 
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("SinhVien");
                // Add header
                worksheet.Cells[1, 1].Value = "Mã Sinh Viên";
                worksheet.Cells[1, 2].Value = "Tên Sinh Viên";
                worksheet.Cells[1, 3].Value = "Số Điện Thoại";
                worksheet.Cells[1, 4].Value = "Giới Tính";
                worksheet.Cells[1, 5].Value = "Địa Chỉ";
                worksheet.Cells[1, 6].Value = "Ngày Nhập Học";
                worksheet.Cells[1, 7].Value = "CCCD";
                worksheet.Cells[1, 8].Value = "Email";
                worksheet.Cells[1, 9].Value = "Khoa";
                worksheet.Cells[1, 10].Value = "Chuyên Ngành";
                worksheet.Cells[1, 11].Value = "Dân Tộc";
                worksheet.Cells[1, 12].Value = "Ngày Sinh";
                worksheet.Cells[1, 13].Value = "Ngày Thêm";
                worksheet.Cells[1, 14].Value = "Tình Trạng";
                worksheet.Cells[1, 15].Value = "Ảnh Sinh Viên";

                // Add data
                for (int i = 0; i < sinhViens.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = sinhViens[i].MaSinhVien;
                    worksheet.Cells[i + 2, 2].Value = sinhViens[i].TenSinhVien;
                    worksheet.Cells[i + 2, 3].Value = sinhViens[i].SoDienThoai;
                    worksheet.Cells[i + 2, 4].Value = sinhViens[i].GioiTinh;
                    worksheet.Cells[i + 2, 5].Value = sinhViens[i].DiaChi;
                    worksheet.Cells[i + 2, 6].Value = sinhViens[i].NgayNhapHoc;
                    worksheet.Cells[i + 2, 6].Style.Numberformat.Format = "dd/MM/yyyy hh:mm:ss";
                    worksheet.Cells[i + 2, 7].Value = sinhViens[i].CCCD;
                    worksheet.Cells[i + 2, 8].Value = sinhViens[i].Email;
                    worksheet.Cells[i + 2, 9].Value = sinhViens[i].Khoa;
                    worksheet.Cells[i + 2, 10].Value = sinhViens[i].ChuyenNganh;
                    worksheet.Cells[i + 2, 11].Value = sinhViens[i].DanToc;
                    worksheet.Cells[i + 2, 12].Value = sinhViens[i].NgaySinh;
                    worksheet.Cells[i + 2, 12].Style.Numberformat.Format = "dd/MM/yyyy hh:mm:ss";
                    worksheet.Cells[i + 2, 13].Value = sinhViens[i].NgayThem;
                    worksheet.Cells[i + 2, 13].Style.Numberformat.Format = "dd/MM/yyyy hh:mm:ss";
                    worksheet.Cells[i + 2, 14].Value = sinhViens[i].TinhTrang;
                    worksheet.Cells[i + 2, 15].Value = sinhViens[i].AnhSinhVien;
                }
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                return package.GetAsByteArray();
            }

        }
    }
}

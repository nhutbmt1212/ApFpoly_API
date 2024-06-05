using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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
                .Skip((page - 1) * pageSize).Where(s => s.TinhTrang != "Đã xóa" && s.TinhTrang != "Ngưng hoạt động")
                .Take(pageSize).OrderByDescending(x => x.NgayThem).ToList();
            return productPerPage;
        }



        public List<SinhVien> LaySinhVien()
        {
            var getSinhVien = _db.SinhVien.Where(s => s.TinhTrang != "Đã xóa" || s.TinhTrang != "Ngưng hoạt động").ToList();
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
                var students =  _db.SinhVien.AsEnumerable()
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
    }
}

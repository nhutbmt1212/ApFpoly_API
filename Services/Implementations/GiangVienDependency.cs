using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            var getGiangVien = _db.GiangVien.Where(s=>s.TinhTrang != "Đã xóa" && s.TinhTrang != "Ngưng hoạt động").ToList();
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
                                        || RemoveDiacritics(s.TenGiangVien.ToLower()).Contains(searchString)
                                       );
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
    }
}


using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            var getGiangVien = _db.GiangVien.ToList();
            return getGiangVien;
        }

        public GiangVien LayGiangVienTheoMaGiangVien(string MaGiangVien)
        {
            var getGiangVienTheoId = _db.GiangVien.FirstOrDefault(s => s.MaGiangVien == MaGiangVien);
            return getGiangVienTheoId;
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
    }
}


using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApFpoly_API.Services.Implementations
{
    public class SinhVienDependency : ISinhVienDependency
    {
        DataContext _db;
        public SinhVienDependency(DataContext db)
        {
            _db = db;
        }
        public List<SinhVien> LaySinhVien()
        {
            var getSinhVien = _db.SinhVien.Where(s => s.TinhTrang != "Đã xóa" && s.TinhTrang != "Ngưng hoạt động").ToList();
            return getSinhVien;
        }

        public SinhVien LaySinhVienTheoMaSinhVien(string MaSinhVien)
        {
            var getSinhVienTheoId = _db.SinhVien.FirstOrDefault(s => s.MaSinhVien == MaSinhVien);
            return getSinhVienTheoId;
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

    }
}

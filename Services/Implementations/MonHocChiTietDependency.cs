using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApFpoly_API.Services.Implementations
{
    public class MonHocChiTietDependency : IMonHocChiTietDependency
    {
        DataContext _db;
        public MonHocChiTietDependency(DataContext db)
        {
            _db = db;
        }
        public List<MonHocChiTiet> LayMonHocChiTiet()
        {
            var getMonHocChiTiet = _db.MonHocChiTiet.Include(x=>x.HocKyBlock).Include(x=>x.GiangVien).Include(x=>x.MonHoc).Include(x=>x.PhongHoc).ToList();
            return getMonHocChiTiet;
        }

        public MonHocChiTiet LayMonHocChiTietTheoMonHocChiTiet(string MaMonHocChiTiet)
        {
            var getMonHocChiTietTheoId = _db.MonHocChiTiet.FirstOrDefault(s => s.MaMonHocChiTiet == MaMonHocChiTiet);
            return getMonHocChiTietTheoId;
        }

        public async Task<MonHocChiTiet> SuaMonHocChiTiet(MonHocChiTiet monHocChiTiet)
        {
            try
            {
                var existMonHocChiTiet = await _db.MonHocChiTiet.FirstOrDefaultAsync(s => s.MaMonHocChiTiet == monHocChiTiet.MaMonHocChiTiet);
                if (existMonHocChiTiet == null)
                {
                    throw new Exception("Không có môn học chi tiết này");
                }
                _db.Entry(existMonHocChiTiet).CurrentValues.SetValues(monHocChiTiet);
                await _db.SaveChangesAsync();
                return existMonHocChiTiet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MonHocChiTiet ThemMonHocChiTiet(MonHocChiTiet monHocChiTiet)
        {
            try
            {
                _db.MonHocChiTiet.Add(monHocChiTiet);
                _db.SaveChanges();
                return monHocChiTiet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MonHocChiTiet> XoaMonHocChiTiet(string MaMonHocChiTiet)
        {
            try
            {
                var existMonHocChiTiet = await _db.MonHocChiTiet.FirstOrDefaultAsync(s => s.MaMonHocChiTiet == MaMonHocChiTiet);
                if (existMonHocChiTiet == null)
                {
                    throw new Exception("Mã nhân viên không tồn tại");
                }
                existMonHocChiTiet.TinhTrang = "Đã xóa";
                _db.MonHocChiTiet.Update(existMonHocChiTiet);
                _db.SaveChanges();
                return existMonHocChiTiet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

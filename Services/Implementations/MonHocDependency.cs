using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            var getMonHoc = _db.MonHoc.Where(s => s.TinhTrang != "Đã xóa" && s.TinhTrang != "Ngưng hoạt động").ToList();
            return getMonHoc;
        }

        public MonHoc LayMonHocTheoMaMonHoc(string MaMonHoc)
        {
            var getMonHocTheoId = _db.MonHoc.FirstOrDefault(s => s.MaMonHoc == MaMonHoc);
            return getMonHocTheoId;
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
    }
}

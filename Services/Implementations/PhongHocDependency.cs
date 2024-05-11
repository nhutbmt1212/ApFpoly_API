using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            var getPhongHoc = _db.PhongHoc.ToList();
            return getPhongHoc;
        }

        public PhongHoc LayPhongHocTheoMaPhongHoc(string MaPhongHoc)
        {
            var getPhongHocTheoId = _db.PhongHoc.FirstOrDefault(s => s.MaPhong == MaPhongHoc);
            return getPhongHocTheoId;
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
                    throw new Exception("Mã nhân viên không tồn tại");
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

    }
}

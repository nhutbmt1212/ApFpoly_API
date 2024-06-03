using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApFpoly_API.Services.Implementations
{
    public class DiemDanhDependency : IDiemDanhDependency
    {
        private readonly DataContext _db;
        public DiemDanhDependency(DataContext db)
        {
            _db = db;
        }

        public async Task<DiemDanh> KiemTraDiemDanhChoSinhVien(string MaSinhVien, string MaLichHoc)
        {
            try
            {
                var diemDanh = await _db.DiemDanh.FirstOrDefaultAsync(s => s.MaSinhVien == MaSinhVien && s.MaLichHoc == MaLichHoc);
                return diemDanh;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DiemDanh>> LayDiemDanhTuMaLichHoc(string MaLichHoc)
        {
            var diemDanhs = await _db.DiemDanh.Where(s => s.MaLichHoc == MaLichHoc)
                 .Include(x => x.LichHoc)
                 .Include(x => x.SinhVien)
                 .Include(x => x.MonHoc)
                 .Include(x => x.GiangVien)
                 .ToListAsync();

            return diemDanhs;

        }

        public async Task<IEnumerable<DiemDanh>> LuuDiemDanh(List<DiemDanh> diemDanhs)
        {
            try
            {
               await _db.DiemDanh.AddRangeAsync(diemDanhs);
               await  _db.SaveChangesAsync();
                return await Task.FromResult(diemDanhs as IEnumerable<DiemDanh>);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DiemDanh>> SuaDiemDanh(List<DiemDanh> diemDanhs)
        {
            try
            {
                 _db.DiemDanh.UpdateRange(diemDanhs);
                await _db.SaveChangesAsync();
                return diemDanhs;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

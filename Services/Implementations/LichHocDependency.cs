using ApFpoly_API.Data;
using ApFpoly_API.DTO;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApFpoly_API.Services.Implementations
{
    public class LichHocDependency : ILichHocDependency
    {
        private readonly DataContext _dbContext;

        public LichHocDependency(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<LichHoc> LayDanhSachLichHoc()
        {
            return _dbContext.LichHoc.Include(x => x.GiangVien).Include(x => x.LopHoc).Include(x => x.MonHoc).Include(x => x.PhongHoc).Where(s => s.TinhTrang != "Đã xóa" && s.TinhTrang != "Ngưng hoạt động").ToList();
        }

        public LichHoc LayLichHocTheoId(string id)
        {
            return _dbContext.LichHoc.FirstOrDefault(x => x.MaLichHoc == id);
        }

        public List<LichHoc> LayLichHocTheoMaHocKyBlockVaLop(HocKyBlockVaLopDTO hocKyBlockVaLopDTO)
        {
            return _dbContext.LichHoc.Include(x => x.GiangVien).Include(x => x.LopHoc).Include(x => x.MonHoc).Include(x => x.PhongHoc).Where(x => x.MaHocKyBlock == hocKyBlockVaLopDTO.MaHocKyBlock && x.MaLop == hocKyBlockVaLopDTO.MaLop).ToList();
        }

        public List<LichHoc> ThemLichHoc(List<LichHoc> lichHoc)
        {
            _dbContext.LichHoc.AddRange(lichHoc);
            _dbContext.SaveChanges();
            return lichHoc;
        }

        public LichHoc SuaLichHoc(LichHoc lichHoc)
        {
            _dbContext.LichHoc.Update(lichHoc);
            _dbContext.SaveChanges();
            return lichHoc;
        }

        public LichHoc XoaLichHoc(string id)
        {
            var lichHoc = _dbContext.LichHoc.FirstOrDefault(x => x.MaLichHoc == id);
            if (lichHoc != null)
            {
                _dbContext.LichHoc.Remove(lichHoc);
                _dbContext.SaveChanges();
            }
            return lichHoc;
        }

        public async Task<IEnumerable<LichHoc>> LayLichHocTheoMaLopVaMaHocKyBlock(string MaLop, string MaHocKyBlock)
        {
            var monHocs = await _dbContext.LichHoc
                .Where(s => s.MaLop == MaLop && s.MaHocKyBlock == MaHocKyBlock)
                .Include(x => x.GiangVien)
                .Include(x => x.LopHoc)
                .Include(x => x.MonHoc)
                .Include(x => x.PhongHoc)
                .Include(x => x.HocKyBlock)
                .ToListAsync();
            return monHocs;
        }

        public async Task<IEnumerable<LichHoc>> LayLichHocTheoIdLop(string id)
        {
            var lichHocs = await _dbContext.LichHoc
                .Where(s => s.MaLop == id)
                  .Include(x => x.GiangVien)
                .Include(x => x.LopHoc)
                .Include(x => x.MonHoc)
                .Include(x => x.PhongHoc)
                .Include(x => x.HocKyBlock)
                .ToListAsync();
            return lichHocs;
        }
    }
}

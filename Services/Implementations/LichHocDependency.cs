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
        public async Task<IEnumerable<LichHoc>> LayLichHocUniqueMonHocTheoMaLop(string MaLop, string MaHocKyBlock)
        {
            // Giả sử _dbContext là một instance của DbContext của bạn
            var lichHocs = await _dbContext.LichHoc
                .Include(x => x.LopHoc)
                .Include(x => x.MonHoc)
                .Include(x => x.PhongHoc)
                .Include(x => x.HocKyBlock)
.Include(x => x.GiangVien)
        .Where(lh => lh.MaLop == MaLop && lh.MaHocKyBlock == MaHocKyBlock)
        .GroupBy(lh => lh.MaMonHoc)
        .Select(g => g.First())


        .ToListAsync();

            return lichHocs;
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

        public async Task<IEnumerable<LichHoc>> SuaLichHoc(List<LichHoc> lichHoc)
        {
            _dbContext.LichHoc.UpdateRange(lichHoc);
            _dbContext.SaveChangesAsync();
            return lichHoc;
        }


        public async Task<List<LichHoc>> CheckByIdLopIdHocKyBlockIdMonAndNgayLichHoc(List<LichHoc> lichHoc)
        {
            List<LichHoc> validLichHoc = new List<LichHoc>();

            try
            {
                foreach (var lh in lichHoc)
                {
                    var lhThoiGianBatDau = ConvertDatetimeToDateOnly(lh.ThoiGianBatDau);
                    var isExist = (await _dbContext.LichHoc
                        .AsNoTracking()
                        .Where(x => x.MaLop == lh.MaLop && x.MaMonHoc == lh.MaMonHoc && x.MaHocKyBlock == lh.MaHocKyBlock)
                        .ToListAsync())
                        .FirstOrDefault(x => ConvertDatetimeToDateOnly(x.ThoiGianBatDau) == lhThoiGianBatDau);


                    if (isExist != null)
                    {
                        if (isExist.MaLichHoc == null)
                        {
                            throw new Exception("MaLichHoc is null");
                        }

                        lh.MaLichHoc = isExist.MaLichHoc;

                        // Include related properties into lh
                        lh.GiangVien = isExist.GiangVien;
                        lh.LopHoc = isExist.LopHoc;
                        lh.MonHoc = isExist.MonHoc;
                        lh.PhongHoc = isExist.PhongHoc;
                        lh.HocKyBlock = isExist.HocKyBlock;

                        validLichHoc.Add(lh);
                    }
                    else
                    {
                        throw new Exception("LichHoc is null");
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ ở đây
                throw new Exception(ex.Message);
            }

            return validLichHoc;
        }

        public DateOnly ConvertDatetimeToDateOnly(DateTime paramDatetime)
        {
            return DateOnly.FromDateTime(paramDatetime);
        }


        public async Task<IEnumerable<LichHoc>> XoaLichHoc(List<LichHoc> lichHoc)
        {
            _dbContext.LichHoc.RemoveRange(lichHoc);
            _dbContext.SaveChangesAsync();
            return lichHoc;
        }

        public async Task<IEnumerable<LichHoc>> LayLichHoctheoIdMonHocIdLopVaIdHocKyBlock(string MaLop, string MaMonHoc, string MaHocKyBlock)
        {
            var lichHocs = await _dbContext.LichHoc
                .Where(s=>s.MaLop == MaLop && s.MaMonHoc == MaMonHoc && s.MaHocKyBlock == MaHocKyBlock)
                .Include(x => x.GiangVien)
                .Include(x => x.LopHoc)
                .Include(x => x.MonHoc)
                .Include(x => x.PhongHoc)
                .Include(x => x.HocKyBlock).ToListAsync();
            return lichHocs;
        }

        public async Task<IEnumerable<LichHoc>> LayLichHocTheoMaGiangVien(string MaGiangVien, string MaHocKyBlock)
        {
            var lichHocs = await _dbContext.LichHoc
                .Where(s => s.MaGiangVien == MaGiangVien && s.MaHocKyBlock == MaHocKyBlock)
                 .Include(x => x.GiangVien)
                .Include(x => x.LopHoc)
                .Include(x => x.MonHoc)
                .Include(x => x.PhongHoc)
                .Include(x => x.HocKyBlock).ToListAsync();
            return lichHocs;
        }
    }
}

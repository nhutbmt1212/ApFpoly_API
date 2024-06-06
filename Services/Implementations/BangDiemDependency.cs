using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApFpoly_API.Services.Implementations
{
    public class BangDiemDependency : IBangDiemDependency
    {
        private readonly DataContext _db;
        public BangDiemDependency(DataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<BangDiem>> LayBangDiemTheoIdLop(string MaLop)
        {
            var bangDiems = await _db.BangDiem.Where(s => s.MaLop == MaLop).ToListAsync();
            return bangDiems;
        }

        public async Task<BangDiem> ThemBangDiem(BangDiem bangDiem)
        {
            try
            {
                _db.BangDiem.Add(bangDiem);
                _db.SaveChanges();
                return bangDiem;
            }
            catch
            (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

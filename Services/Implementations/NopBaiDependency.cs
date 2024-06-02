using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApFpoly_API.Services.Implementations
{
    public class NopBaiDependency : INopBaiDependency
    {
        private readonly DataContext _db; 
        public NopBaiDependency(DataContext db)
        {
            _db = db;

        }

        public async Task<IEnumerable<NopBai>> GetNopBaiTheoIdLopVaMonHoc(string MaLop, string MaMonHoc)
        {
            var nopBais =  _db.NopBai.Where(s => s.MaLop == MaLop && s.MaMonHoc == MaMonHoc)
                .Include(s => s.LopHoc)
                .Include(s => s.SinhVien)
                .Include(s => s.MonHoc)
                .Include(s => s.GiangVien)
                .ToList();
            return nopBais;
        }

        public async Task<NopBai> SuaNopBai(NopBai nopBai)
        {
            try
            {
            _db.Update(nopBai);
                _db.SaveChangesAsync();
                return nopBai;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NopBai> ThemNopBai(NopBai nopBai)
        {
            try
            {
                _db.NopBai.Add(nopBai);
                _db.SaveChanges();
                return nopBai;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }

        }
    }
}

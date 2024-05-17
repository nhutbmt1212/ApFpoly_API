using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _dbContext.LichHoc.Where(s => s.TinhTrang != "Đã xóa" && s.TinhTrang != "Ngưng hoạt động").ToList();
        }

        public LichHoc LayLichHocTheoId(string id)
        {
            return _dbContext.LichHoc.FirstOrDefault(x => x.MaLichHoc == id);
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
    }
}

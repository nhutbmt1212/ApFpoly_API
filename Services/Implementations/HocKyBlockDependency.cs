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
    public class HocKyBlockDependency : IHocKyBlockDependency
    {
        private readonly DataContext _dbContext;

        public HocKyBlockDependency(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<HocKyBlock> LayHocKyBlock()
        {
            return _dbContext.HocKyBlock.Where(s => s.TinhTrang != "Đã xóa" && s.TinhTrang != "Ngưng hoạt động").ToList();
        }

        public HocKyBlock LayHocKyBlockTheoMa(string MaHocKyBlock)
        {
            return _dbContext.HocKyBlock.FirstOrDefault(x => x.MaHocKyBlock == MaHocKyBlock);
        }

        public HocKyBlock ThemHocKyBlock(HocKyBlock hocKyBlock)
        {
            _dbContext.HocKyBlock.Add(hocKyBlock);
            _dbContext.SaveChanges();
            return hocKyBlock;
        }

        public async Task<HocKyBlock> SuaHocKyBlock(HocKyBlock hocKyBlock)
        {
            _dbContext.HocKyBlock.Update(hocKyBlock);
            await _dbContext.SaveChangesAsync();
            return hocKyBlock;
        }

        public async Task<HocKyBlock> XoaHocKyBlock(string MaHocKyBlock)
        {
            var hocKyBlock = _dbContext.HocKyBlock.FirstOrDefault(x => x.MaHocKyBlock == MaHocKyBlock);
            if (hocKyBlock != null)
            {
                _dbContext.HocKyBlock.Remove(hocKyBlock);
                await _dbContext.SaveChangesAsync();
            }
            return hocKyBlock;
        }
    }
}

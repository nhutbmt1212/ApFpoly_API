using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
            return _dbContext.HocKyBlock.Where(s => s.TinhTrang != "Đã xóa").ToList();
        }
        public async Task<IEnumerable<HocKyBlock>> SearchingHocKyBlock(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = RemoveDiacritics(searchString).ToLower();
                var hocKyBlocks = _dbContext.HocKyBlock.AsEnumerable()
                               .Where(s => RemoveDiacritics(s.MaHocKyBlock.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TenHocKy.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TenBlock.ToLower()).Contains(searchString) || s.TinhTrang != "Đã xóa" ).Take(5);
                                     
                return hocKyBlocks.ToList();
            }
            else
            {
                return await _dbContext.HocKyBlock.ToListAsync();
            }
        }


        public static string RemoveDiacritics(string text)
        {
            var normalized = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    if (c == 'đ') stringBuilder.Append('d');
                    else if (c == 'Đ') stringBuilder.Append('D');
                    else stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
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

        public HocKyBlock LayHocKyBlockHienTai()
        {
            DateTime datetime = DateTime.Now;
            var hocKyBlock = _dbContext.HocKyBlock.FirstOrDefault(x=>x.NgayBatDau < datetime && x.NgayKetThuc > datetime);
            return hocKyBlock;
        }
        public async Task<IEnumerable<HocKyBlock>> SearchingHocKyBlockForTimKiem(string searchString, int limitItem)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = RemoveDiacritics(searchString).ToLower();
                var students = _dbContext.HocKyBlock.AsEnumerable()
                               .Where(s => RemoveDiacritics(s.MaHocKyBlock.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TenHocKy.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TenBlock.ToString()).Contains(searchString)
                                  )
                               .Take(limitItem)
                               .ToList()
                               ;
                return students;
            }
            else
            {
                return null;
            }
        }
    }
}

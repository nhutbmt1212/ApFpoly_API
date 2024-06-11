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
    public class LopHocDependency : ILopHocDependency
    {
        private readonly DataContext _db;

        public LopHocDependency(DataContext db)
        {
            _db = db;
        }

        public List<LopHoc> LayLopHoc()
        {
            return _db.LopHoc.Where(s => s.TinhTrang != "Đã xóa").ToList();
        }

        public LopHoc LayLopHocTheoMa(string MaLopHoc)
        {
            return _db.LopHoc.FirstOrDefault(s => s.MaLop == MaLopHoc);
        }
        public async Task<IEnumerable<LopHoc>> SearchingLopHoc(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = RemoveDiacritics(searchString).ToLower();
                var lopHocs = _db.LopHoc.AsEnumerable()
                               .Where(s => RemoveDiacritics(s.MaLop.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TenLop.ToLower()).Contains(searchString) || s.TinhTrang != "Đã xóa" 
                                       ).Take(5);
                return lopHocs.ToList();
            }
            else
            {
                return await _db.LopHoc.ToListAsync();
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

        public async Task<LopHoc> SuaLopHoc(LopHoc lopHoc)
        {
            try
            {
                var existLopHoc = await _db.LopHoc.FirstOrDefaultAsync(s => s.MaLop == lopHoc.MaLop);
                if (existLopHoc == null)
                {
                    throw new Exception("Không tìm thấy lớp học này");
                }

                _db.Entry(existLopHoc).CurrentValues.SetValues(lopHoc);
                await _db.SaveChangesAsync();

                return existLopHoc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LopHoc ThemLopHoc(LopHoc lopHoc)
        {
            try
            {
                _db.LopHoc.Add(lopHoc);
                _db.SaveChanges();

                return lopHoc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LopHoc> XoaLopHoc(string MaLopHoc)
        {
            try
            {
                var existLopHoc = await _db.LopHoc.FirstOrDefaultAsync(s => s.MaLop == MaLopHoc);
                if (existLopHoc == null)
                {
                    throw new Exception("Mã lớp học không tồn tại");
                }

                existLopHoc.TinhTrang = "Đã xóa";
                _db.LopHoc.Update(existLopHoc);
                await _db.SaveChangesAsync();

                return existLopHoc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int SoLuongLopHoc()
        {
            return _db.LopHoc.Count();
        }

        public async Task<IEnumerable<LopHoc>> SearchingLopHocForTimKiem(string searchString, int limitItem)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = RemoveDiacritics(searchString).ToLower();
                var lopHocs = _db.LopHoc.AsEnumerable()
                               .Where(s => RemoveDiacritics(s.MaLop.ToLower()).Contains(searchString)
                                        || RemoveDiacritics(s.TenLop.ToLower()).Contains(searchString))
                                      
                               .Take(limitItem)
                               .ToList();
                return lopHocs;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<LopHoc> GetLopHoc(int page, int pageSize)
        {
            if (page < 1)
            {
                page = 1;
            }

            var totalCount = SoLuongLopHoc();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var lopHocPerPage = _db.LopHoc
                .Skip((page - 1) * pageSize).Where(s => s.TinhTrang != "Đã xóa")
                .Take(pageSize).OrderByDescending(x => x.NgayTao).ToList();
            return lopHocPerPage;
        }
    }
}

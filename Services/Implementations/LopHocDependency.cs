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
    public class LopHocDependency : ILopHocDependency
    {
        private readonly DataContext _db;

        public LopHocDependency(DataContext db)
        {
            _db = db;
        }

        public List<LopHoc> LayLopHoc()
        {
            return _db.LopHoc.Where(s => s.TinhTrang != "Đã xóa" && s.TinhTrang != "Ngưng hoạt động").ToList();
        }

        public LopHoc LayLopHocTheoMa(string MaLopHoc)
        {
            return _db.LopHoc.FirstOrDefault(s => s.MaLop == MaLopHoc);
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
    }
}

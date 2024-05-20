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
    public class LopHocChiTietDependency : ILopHocChiTietDependency
    {
        private readonly DataContext _db;

        public LopHocChiTietDependency(DataContext db)
        {
            _db = db;
        }

        public List<LopHocChiTiet> LayLopHocChiTiet()
        {
            return _db.LopHocChiTiet.Where(s => s.TinhTrang != "Đã xóa" && s.TinhTrang != "Ngưng hoạt động").ToList();
        }

        public LopHocChiTiet LayLopHocChiTietTheoMa(string MaLopHocChiTiet)
        {
            return _db.LopHocChiTiet.Include(x=>x.LopHoc).Include(x=>x.SinhVien).FirstOrDefault(s => s.MaLopHocChiTiet == MaLopHocChiTiet);
        }

        public  List<LopHocChiTiet> LayLopHocChiTietTheoMaLop(string MaLop)
        {
            return _db.LopHocChiTiet.Include(x => x.LopHoc).Include(x => x.SinhVien).Where(s => s.MaLop == MaLop).ToList();
        }

        public async Task<LopHocChiTiet> SuaLopHocChiTiet(LopHocChiTiet lopHocChiTiet)
        {
            try
            {
                var existLopHocChiTiet = await _db.LopHocChiTiet.FirstOrDefaultAsync(s => s.MaLopHocChiTiet == lopHocChiTiet.MaLopHocChiTiet);
                if (existLopHocChiTiet == null)
                {
                    throw new Exception("Không tìm thấy lớp học chi tiết này");
                }

                _db.Entry(existLopHocChiTiet).CurrentValues.SetValues(lopHocChiTiet);
                await _db.SaveChangesAsync();

                return existLopHocChiTiet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LopHocChiTiet ThemLopHocChiTiet(LopHocChiTiet lopHocChiTiet)
        {
            try
            {
                _db.LopHocChiTiet.Add(lopHocChiTiet);
                _db.SaveChanges();

                return lopHocChiTiet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LopHocChiTiet> XoaLopHocChiTiet(string MaLopHocChiTiet)
        {
            try
            {
                var existLopHocChiTiet = await _db.LopHocChiTiet.FirstOrDefaultAsync(s => s.MaLopHocChiTiet == MaLopHocChiTiet);
                if (existLopHocChiTiet == null)
                {
                    throw new Exception("Mã lớp học chi tiết không tồn tại");
                }

                existLopHocChiTiet.TinhTrang = "Đã xóa";
                _db.LopHocChiTiet.Update(existLopHocChiTiet);
                await _db.SaveChangesAsync();

                return existLopHocChiTiet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

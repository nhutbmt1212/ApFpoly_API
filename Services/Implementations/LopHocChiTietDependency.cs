﻿using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;
using IronXL;
using Microsoft.EntityFrameworkCore;

namespace ApFpoly_API.Services.Implementations
{
    public class LopHocChiTietDependency : ILopHocChiTietDependency
    {
        private readonly DataContext _db;
        private readonly ISinhVienDependency _sinhVienDependency;
        public LopHocChiTietDependency(DataContext db, ISinhVienDependency sinhVienDependency)
        {
            _db = db;
            _sinhVienDependency = sinhVienDependency;
        }

        public ImportResultLopHocChiTiet ImportSinhVienVaoLopHocChiTiet(string MaLop, IFormFile fileExcel)
        {
            List<LopHocChiTiet> list_LopHocChiTiet = new List<LopHocChiTiet>();
            try
            {
                using (var stream = new MemoryStream())
                {
                    fileExcel.CopyTo(stream);
                    stream.Position = 0;

                    WorkBook workBook = WorkBook.Load(stream);
                    WorkSheet workSheet = workBook.WorkSheets.First();
                    var maSinhVien = workSheet.GetColumn(0);
                    foreach (var item in maSinhVien)
                    {
                        if (item.Value.ToString() != "Mã Sinh Viên" && item.Value.ToString() != "" && item.Value.ToString() != "BẢNG SINH VIÊN TRONG LỚP")
                        {
                            string MaSinhVien = item.Value.ToString();
                            var existSinhVien = LayLopHocChiTietTheoMaLopVaMaSinhVien(MaLop, MaSinhVien);
                            if (existSinhVien == null)
                            {
                                var IsFindMaSinhVien = _sinhVienDependency.LaySinhVienTheoMaSinhVien(MaSinhVien);
                                if (IsFindMaSinhVien != null)
                                {
                                    var obj_LopHocChiTiet = new LopHocChiTiet();
                                    obj_LopHocChiTiet.MaLopHocChiTiet = GenerateRandomString(7);
                                    obj_LopHocChiTiet.MaLop = MaLop;
                                    obj_LopHocChiTiet.MaSinhVien = MaSinhVien;
                                    obj_LopHocChiTiet.TinhTrang = "Đang học";
                                    obj_LopHocChiTiet.SinhVien = IsFindMaSinhVien;
                                    list_LopHocChiTiet.Add(obj_LopHocChiTiet);

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new ImportResultLopHocChiTiet { Success = false, Message = ex.Message, Data = null };
            }

            if (list_LopHocChiTiet.Count == 0)
            {
                return new ImportResultLopHocChiTiet { Success = false, Message = "Không tồn tại sinh viên trong hệ thống", Data = null };
            }



            return new ImportResultLopHocChiTiet { Success = true, Message = "Thành công", Data = list_LopHocChiTiet };
        }


        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray()).ToUpper();
        }


        public List<LopHocChiTiet> LayLopHocChiTiet()
        {
            return _db.LopHocChiTiet.Where(s => s.TinhTrang != "Đã xóa" && s.TinhTrang != "Ngưng hoạt động").ToList();
        }

        public LopHocChiTiet LayLopHocChiTietTheoMa(string MaLopHocChiTiet)
        {
            return _db.LopHocChiTiet.Include(x => x.LopHoc).Include(x => x.SinhVien).FirstOrDefault(s => s.MaLopHocChiTiet == MaLopHocChiTiet);
        }

        public List<LopHocChiTiet> LayLopHocChiTietTheoMaLop(string MaLop)
        {
            return _db.LopHocChiTiet.Include(x => x.LopHoc).Include(x => x.SinhVien).Where(s => s.MaLop == MaLop && s.TinhTrang != "Đã xóa").ToList();
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

        public List<LopHocChiTiet> ThemLopHocChiTiet(List<LopHocChiTiet> lopHocChiTiet)
        {
            try
            {
                _db.LopHocChiTiet.AddRange(lopHocChiTiet);
                _db.SaveChanges();

                return lopHocChiTiet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

        public LopHocChiTiet LayLopHocChiTietTheoMaLopVaMaSinhVien(string MaLop, string MaSinhVien)
        {
            var existSinhVien = _db.LopHocChiTiet.FirstOrDefault(s => s.MaSinhVien == MaSinhVien && s.MaLop == MaLop);
            return existSinhVien;
        }

        public async Task<List<LopHocChiTiet>> XoaLopHocChiTiet(List<LopHocChiTiet> lopHocChiTiet)
        {
            try
            {
                _db.LopHocChiTiet.UpdateRange(lopHocChiTiet);
                _db.SaveChanges();

                return lopHocChiTiet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

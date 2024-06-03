using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;

namespace ApFpoly_API.Services.Implementations
{
    public class ValidateDependency : IValidateDependency
    {
        private readonly DataContext _db;
        public ValidateDependency(DataContext db)
        {
            _db = db;
        }
        public bool KiemTraTrungCCCDTrongHeThong(string cccd)
        {
            var existSinhVien = _db.SinhVien.FirstOrDefault(x => x.CCCD == cccd);
            if (existSinhVien == null)
            {
                var existGiangVien = _db.GiangVien.FirstOrDefault(y => y.CCCD == cccd);
                if (existGiangVien != null)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        public bool KiemTraTrungEmailTrongHeThong(string email)
        {
            var existSinhVien = _db.SinhVien.FirstOrDefault(x => x.Email == email);
            if (existSinhVien == null)
            {
                var existGiangVien = _db.GiangVien.FirstOrDefault(y => y.Email == email);
                if (existGiangVien != null)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        public bool KiemTraTrungMaGiangVienTrongHeThong(string maGiangVien)
        {
            var existMaGiangVien = _db.GiangVien.FirstOrDefault(s => s.MaGiangVien == maGiangVien);
            if (existMaGiangVien == null)
            {
                return false;
            }
            return true;
        }

        public bool KiemTraTrungMaHocKyBlockTrongHeThong(string maHocKyBlock)
        {
            var existMaHocKyBlock = _db.HocKyBlock.FirstOrDefault(s => s.MaHocKyBlock == maHocKyBlock);
            if (existMaHocKyBlock == null)
            {
                return false;
            }
            return true;
        }

        public bool KiemTraTrungMaLopTrongHeThong(string maLop)
        {
            var existMaLop = _db.LopHoc.FirstOrDefault(l => l.MaLop == maLop);
            if (existMaLop == null)
            {
                return false;
            }
            return true;
        }

        public bool KiemTraTrungMaMonHocTrongHeThong(string maMonHoc)
        {
            var existMaMonHoc = _db.MonHoc.FirstOrDefault(m => m.MaMonHoc == maMonHoc);
            if (existMaMonHoc == null)
            {
                return false;
            }
            return true;
        }

        public bool KiemTraTrungMaPhongTrongHeThong(string maPhong)
        {
            var existMaPhong = _db.PhongHoc.FirstOrDefault(p => p.MaPhong == maPhong);
            if (existMaPhong == null)
            {
                return false;
            }
            return true;
        }


        public bool KiemTraTrungSoDienThoaiTrongHeThong(string soDienThoai)
        {
            var existSinhVien = _db.SinhVien.FirstOrDefault(x => x.SoDienThoai == soDienThoai);
            if (existSinhVien == null)
            {
                var existGiangVien = _db.GiangVien.FirstOrDefault(y => y.SoDienThoai == soDienThoai);
                if (existGiangVien != null)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        public bool ValidateTrungCCCDTrongHeThongTruCCCDHienTai(string MaNguoiDung, string cccd)
        {
            var existSinhVien = _db.SinhVien.FirstOrDefault(x => x.CCCD == cccd && x.MaSinhVien != MaNguoiDung);
            var existGiangVien = _db.GiangVien.FirstOrDefault(y => y.CCCD == cccd && y.MaGiangVien != MaNguoiDung);
            return existSinhVien != null || existGiangVien != null;
        }

        public bool ValidateTrungEmailTrongHeThongTruEmailHienTai(string MaNguoiDung, string email)
        {
            var existSinhVien = _db.SinhVien.FirstOrDefault(x => x.Email == email && x.MaSinhVien != MaNguoiDung);
            var existGiangVien = _db.GiangVien.FirstOrDefault(y => y.Email == email && y.MaGiangVien != MaNguoiDung);
            return existSinhVien != null || existGiangVien != null;
        }

        public bool ValidateTrungSoDienThoaiTrongHeThongTruSoDienThoaiHienTai(string MaNguoiDung, string soDienThoai)
        {
            var existSinhVien = _db.SinhVien.FirstOrDefault(x => x.SoDienThoai == soDienThoai && x.MaSinhVien != MaNguoiDung);
            var existGiangVien = _db.GiangVien.FirstOrDefault(y => y.SoDienThoai == soDienThoai && y.MaGiangVien != MaNguoiDung);
            return existSinhVien != null || existGiangVien != null;
        }

    }
}

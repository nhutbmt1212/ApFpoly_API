using System.ComponentModel.DataAnnotations;

namespace ApFpoly_API.DTO
{
    public class SinhVienDTO
    {

        public string MaSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public string SoDienThoai { get; set; }
        public string GioiTinh { get; set; }

        public string DiaChi { get; set; }
        public DateTime NgayNhapHoc { get; set; }

        public string CCCD { get; set; }

        public string Email { get; set; }

        public string Khoa { get; set; }

        public string ChuyenNganh { get; set; }

        public string DanToc { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayThem { get; set; }
        public string TinhTrang { get; set; }
        public string AnhSinhVien { get; set; }
    }
}

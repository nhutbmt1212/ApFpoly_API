using System.ComponentModel.DataAnnotations;

namespace ApFpoly_API.Model
{
    public class SinhVien
    {
        [Key]
        [StringLength(7)]
        public string MaSinhVien { get; set; }
        [MaxLength(55)]
        public string TenSinhVien { get; set; }
        [MaxLength(10)]

        public string SoDienThoai { get; set; }
        [MaxLength(3)]

        public string GioiTinh { get; set; }
        [MaxLength(100)]

        public string DiaChi { get; set; }
        public DateTime NgayNhapHoc { get; set; }
        [MaxLength(12)]

        public string CCCD{ get; set; }
        [MaxLength(70)]

        public string Email { get; set; }
        [MaxLength(10)]

        public string Khoa { get; set; }
        [MaxLength(50)]

        public string ChuyenNganh { get; set; }
        [MaxLength(30)]

        public string DanToc{ get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayThem { get; set; }
        [MaxLength(30)]
        public string TinhTrang { get; set; }
        public string? AnhSinhVien { get; set; }
    }
}

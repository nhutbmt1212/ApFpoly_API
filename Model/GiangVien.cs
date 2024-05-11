using System.ComponentModel.DataAnnotations;

namespace ApFpoly_API.Model
{
    public class GiangVien
    {
        [Key]
        [MaxLength(7)]
        public string MaGiangVien { get; set; }

        [MaxLength(55)]
        public string TenGiangVien { get; set; } 

        [MaxLength(3)]
        public string GioiTinh { get; set; }

        [MaxLength(10)]
        public string SoDienThoai { get; set; }

        public DateTime NgaySinh { get; set; }

        [MaxLength(30)]
        public string DanToc { get; set; }

        [MaxLength(50)]
        public string Nganh { get; set; }

        [MaxLength(70)]
        public string Email { get; set; }

        [MaxLength(12)]
        public string CCCD { get; set; }

        public DateTime NgayVaoLam { get; set; }

        [MaxLength(100)]
        public string DiaChi { get; set; }

        [MaxLength(30)]
        public string ChucVu { get; set; }

        public DateTime NgayThem { get; set; }

        [MaxLength(30)]
        public string TinhTrang { get; set; }

        public string? AnhGiangVien { get; set; }


    }
}

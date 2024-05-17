using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApFpoly_API.Model
{
    public class LichHoc
    {
        [Key]
        [MaxLength(7)]
        public string MaLichHoc { get; set; } // Khóa chính
        [Required]
        public DateTime ThoiGianBatDau { get; set; }
        [Required]
        public DateTime ThoiGianKetThuc { get; set; }
        [Required,MaxLength(30)]
        public string TinhTrang { get; set; }
        [MaxLength(7)]
        public string MaLop { get; set; } // Khóa ngoại
        [ForeignKey("MaLop")]
        public virtual LopHoc LopHoc { get; set; }
        [MaxLength(7)]
        public string MaHocKyBlock { get; set; } // Khóa ngoại
        [ForeignKey("MaHocKyBlock")]
        public virtual HocKyBlock HocKyBlock { get; set; }
        [MaxLength(7)]
        public string MaPhong { get; set; } // Khóa ngoại
        [ForeignKey("MaPhong")]
        public virtual PhongHoc PhongHoc { get; set; }
        [MaxLength(7)]
        public string MaGiangVien { get; set; } // Khóa ngoại
        [ForeignKey("MaGiangVien ")]
        public virtual GiangVien GiangVien { get; set; }
        [MaxLength(7)]
        public string MaMonHoc { get; set; } // Khóa ngoại
        [ForeignKey("MaMonHoc")]
        public virtual MonHoc MonHoc { get; set; }
    }
}

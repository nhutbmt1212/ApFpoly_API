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
        public string MaMonHocChiTiet { get; set; } // Khóa ngoại
        [ForeignKey("MaMonHocChiTiet")]
        public virtual MonHocChiTiet MonHocChiTiet { get; set; }
    }
}

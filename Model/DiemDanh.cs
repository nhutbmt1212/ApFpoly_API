using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApFpoly_API.Model
{
    public class DiemDanh
    {
        [Key]
        public string MaDiemDanh { get; set; }

        [MaxLength(7)]
        public string MaLichHoc { get; set; }

        [ForeignKey("MaLichHoc")]
        public virtual LichHoc LichHoc { get; set; }

        [MaxLength(7)]
        public string MaSinhVien { get; set; }

        [ForeignKey("MaSinhVien")]
        public virtual SinhVien SinhVien { get; set; }

        [MaxLength(7)]
        public string MaMonHoc { get; set; }

        [ForeignKey("MaMonHoc")]
        public virtual MonHoc MonHoc { get; set; }

        [MaxLength(7)]
        public string MaGiangVien { get; set; }

        [ForeignKey("MaGiangVien")]
        public virtual GiangVien GiangVien { get; set; }

        [Required]
        public bool CoMat { get; set; }

        [Required]
        public DateTime NgayTao { get; set; }
        [MaxLength(30)]
        public string TinhTrang { get; set; }
    }
}

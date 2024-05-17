using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApFpoly_API.Model
{
    public class MonHocChiTiet
    {
        [Key]
        [StringLength(7)]
        public string MaMonHocChiTiet { get; set; }

        [StringLength(7)]
        public string MaMonHoc { get; set; }
        [ForeignKey("MaMonHoc")]
        public virtual MonHoc MonHoc { get; set; }

        [StringLength(7)]
        public string MaGiangVien { get; set; }
        [ForeignKey("MaGiangVien")]
        public virtual GiangVien GiangVien { get; set; }

        [StringLength(7)]
        public string MaPhong { get; set; }
        [ForeignKey("MaPhong")]
        public virtual PhongHoc PhongHoc { get; set; }

        [StringLength(7)]
        public string MaHocKyBlock { get; set; }
        [ForeignKey("MaHocKyBlock")]
        public virtual HocKyBlock HocKyBlock { get; set; }

        [Required]
        public DateTime NgayBatDau { get; set; }
        
        [Required]
        public DateTime NgayKetThuc { get; set; }

        [MaxLength(30),Required]

        public string TinhTrang { get; set; }

    }
}

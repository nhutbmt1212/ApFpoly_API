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
        public string MaSinhVien { get; set; }
        [ForeignKey("MaSinhVien")]
        public virtual SinhVien SinhVien { get; set;}


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


        public sbyte? DiemSo { get; set; }

        [Required]
        public sbyte? HocKy { get; set; }

        [MaxLength(15), Required]
        public string? Lop { get; set; }

        [MaxLength(1), Required]
        public sbyte? Block { get; set; }

        [Required]
        public DateTime NgayBatDau { get; set; }
        
        [Required]
        public DateTime NgayKetThuc { get; set; }

        [MaxLength(30),Required]

        public string TinhTrang { get; set; }

    }
}

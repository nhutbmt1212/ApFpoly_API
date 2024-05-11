using System.ComponentModel.DataAnnotations;

namespace ApFpoly_API.Model
{
    public class PhongHoc
    {
        [Key]
        [StringLength(7)]
        public string MaPhong { get; set; }

        [MaxLength(50), Required]
        public string TenPhong { get; set; }

        [Required]
        public DateTime NgayTao { get; set; }

        [MaxLength(40), Required]
        public string LoaiPhong { get; set; }

        [Required]

        public short SucChua { get; set; }

        [MaxLength(30), Required]
        public string TinhTrang { get; set; }

    }
}

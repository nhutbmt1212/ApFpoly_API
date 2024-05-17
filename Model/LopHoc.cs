using System.ComponentModel.DataAnnotations;

namespace ApFpoly_API.Model
{
    public class LopHoc
    {
        [Key]
        [MaxLength(7)]
        public string MaLop { get; set; } 
        [MaxLength(40)]
        [Required]
        public string TenLop { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        [Required]
        public sbyte SucChua { get; set; }
        [MaxLength(30),Required]
        public string TinhTrang { get; set; }
    }
}

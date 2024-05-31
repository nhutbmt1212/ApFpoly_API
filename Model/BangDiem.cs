using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApFpoly_API.Model
{
    public class BangDiem
    {
        [Key]
        [MaxLength(7)]
        public string MaBangDiem { get; set; }
        [MaxLength(7)]
      

        public string MaLop { get; set; }
        [ForeignKey("MaLop")]
        public virtual LopHoc LopHoc { get; set; }

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
        public double Diem { get; set; }
        [Required]

        public DateTime NgayTao { get; set; }
    }
}

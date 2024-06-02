using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApFpoly_API.Model
{
    public class NopBai
    {
        [Key]
        [MaxLength(7)]
        public string MaNopBai { get; set; }
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

        [MaxLength(200),Required]
        public string TenFileNop { get; set; }

        [MaxLength(30),Required]
        public string PhuongThucNopBai { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        [MaxLength(30)]
        public string TinhTrang { get; set; }   
    }
}

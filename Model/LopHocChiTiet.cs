using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApFpoly_API.Model
{
    public class LopHocChiTiet
    {
        [Key]
        [MaxLength(7)]
        public string MaLopHocChiTiet { get; set; } // Khóa chính
        [StringLength(7)]
        public string MaLop { get; set; } // Khóa ngoại
        [ForeignKey("MaLop")]
        public virtual LopHoc LopHoc { get; set; }
        [StringLength(7)]
        public string MaSinhVien { get; set; } // Khóa ngoại
        [ForeignKey("MaSinhVien")]
        public virtual SinhVien SinhVien { get; set; }
       
   
        [Required,MaxLength(30)]
        public string TinhTrang { get; set; }
    }

    public class ImportResultLopHocChiTiet
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<LopHocChiTiet> Data { get; set; }
    }
}

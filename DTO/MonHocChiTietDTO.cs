using ApFpoly_API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApFpoly_API.DTO
{
    public class MonHocChiTietDTO
    {
      
        public string MaMonHocChiTiet { get; set; }
        public string MaSinhVien { get; set; }
        public string MaMonHoc { get; set; }
        public string MaGiangVien { get; set; }
        public string MaPhong { get; set; }
        public string MaHocKyBlock { get; set; }
        public sbyte? DiemSo { get; set; }
        public sbyte? HocKy { get; set; }
        public string? Lop { get; set; }
        public sbyte? Block { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string TinhTrang { get; set; }
    }
}

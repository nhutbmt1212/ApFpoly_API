using ApFpoly_API.Model;
using System;

namespace ApFpoly_API.DTO
{
    public class LichHocDTO
    {
        public string? MaLichHoc { get; set; }

        public TimeOnly GioBatDau { get; set; }

        public TimeOnly GioKetThuc { get; set; }
    
        public string? TinhTrang { get; set; }
        public string MaLop { get; set; }
        public string MaHocKyBlock { get; set; }
        public string MaPhong { get; set; }
        public string? MaGiangVien { get; set; }
        public string MaMonHoc { get; set; }
        public List<DateTime>? NgayLichHoc { get;set; }

    }

    public class LichHocDTOValidate
    {
        public string MaLichHoc { get; set; }
        public string MaLop { get; set; }
        public string MaHocKyBlock { get; set; }
        public string MaPhong { get; set; }
        public string MaGiangVien { get; set; }
        public string MaMonHoc { get; set; }
    }

    public class LichHocDTOForGet
    {
        public string MaLop { get; set; }
        public string? MaGiangVien { get; set; }
        public string? MaPhongHoc { get; set; }
      
        public List<MonHoc> MonHoc { get; set; }
        public LopHoc LopHoc { get; set; }
        public GiangVien? GiangVien { get; set; }
        public PhongHoc? PhongHoc { get; set; }
       
        public int? soLuongNguoiTrongLop { get; set; }
        public int sucChua { get; set; }
    }
}

using System;

namespace ApFpoly_API.DTO
{
    public class LichHocDTO
    {
        public string MaLichHoc { get; set; }

        public TimeOnly GioBatDau { get; set; }

        public TimeOnly GioKetThuc { get; set; }
    
        public string TinhTrang { get; set; }
        public string MaLop { get; set; }
        public string MaHocKyBlock { get; set; }
        public string MaPhong { get; set; }
        public string MaGiangVien { get; set; }
        public string MaMonHoc { get; set; }
        public List<DateTime> NgayLichHoc { get;set; }

    }
}

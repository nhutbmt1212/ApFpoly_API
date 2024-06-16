using ApFpoly_API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApFpoly_API.DTO
{
    public class BangDiemDTO

    {
     
        public string MaBangDiem { get; set; }
       


        public string MaLop { get; set; }
    
        public string MaSinhVien { get; set; }
       
        public string MaMonHoc { get; set; }
      
        public string MaGiangVien { get; set; }
       
        public double Diem { get; set; }
       
        public DateTime NgayTao { get; set; }
       
        public string TinhTrang { get; set; }
    }
    public class LopBangDiemDTO
    {
        public string MaLop { get; set; }
        public LopHoc LopHoc { get; set; }
        public string MaGiangVien { get; set; }
        public GiangVien GiangVien { get; set; }
        public string MaMonHoc { get; set; }
        public MonHoc MonHoc { get; set; }
        public string MaHocKyBlock { get; set; }
        public HocKyBlock HocKyBlock { get; set; }
        public int SiSo { get; set; }
        public int TongSoNop { get; set; }
        public string TinhTrang { get; set; }
    }
}

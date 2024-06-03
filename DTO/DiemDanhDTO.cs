using ApFpoly_API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApFpoly_API.DTO
{
    public class DiemDanhDTO
    {
     
        public string MaDiemDanh { get; set; }

       
        public string MaLichHoc { get; set; }

        public string MaSinhVien { get; set; }

        public string MaMonHoc { get; set; }

        public string MaGiangVien { get; set; }

        public string CoMat { get; set; }

        public DateTime NgayTao { get; set; }
 
        public string TinhTrang { get; set; }
    }
}

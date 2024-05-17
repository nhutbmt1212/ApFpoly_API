using System.ComponentModel.DataAnnotations;

namespace ApFpoly_API.Model
{
    public class MonHoc
    {
        [Key]
        [StringLength(7)]
        public string MaMonHoc {  get; set; }

        [MaxLength(60)]
        public string TenMonHoc { get; set; }

        public DateTime NgayTao { get; set; }

     
        public sbyte? TinChi { get; set; }
        public sbyte SoBuoi { get; set; }
        public string? NoiDungMonHoc { get; set; }


        public string? TaiLieu { get; set; }

        [MaxLength(30)]
        public string TinhTrang { get; set; }

    }
}

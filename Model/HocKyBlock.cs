using Microsoft.AspNetCore.SignalR.Protocol;
using System.ComponentModel.DataAnnotations;

namespace ApFpoly_API.Model
{
    public class HocKyBlock
    {
        [Key,MaxLength(7)]
        
        public string MaHocKyBlock {  get; set; }
        [MaxLength(30),Required]
        public string TenHocKy { get; set; }
        [MaxLength(15), Required]
        public string TenBlock { get; set; }
        [Required]
        public DateTime NgayBatDau { get; set; }
        [Required]
        public DateTime NgayKetThuc {  get; set; }
        [MaxLength(30), Required]
        public string TinhTrang { get; set; }

    }
}

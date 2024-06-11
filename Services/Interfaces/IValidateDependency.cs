namespace ApFpoly_API.Services.Interfaces
{
    public interface IValidateDependency
    {
        bool KiemTraTrungEmailTrongHeThong(string email);
        bool KiemTraTrungSoDienThoaiTrongHeThong(string soDienThoai);
        bool KiemTraTrungCCCDTrongHeThong(string cccd);
        bool ValidateTrungMaMonHocTrongHeThong(string MaLop, string MaMonHoc);

        bool KiemTraTrungMaLopTrongHeThong(string maLop);
        bool KiemTraTrungMaHocKyBlockTrongHeThong(string maHocKyBlock);
        bool KiemTraTrungMaPhongTrongHeThong(string maPhong);
        bool KiemTraTrungMaMonHocTrongHeThong(string maMonHoc);
        bool KiemTraTrungMaGiangVienTrongHeThong(string maGiangVien);

        bool ValidateTrungEmailTrongHeThongTruEmailHienTai(string MaNguoiDung,string email);
        bool ValidateTrungSoDienThoaiTrongHeThongTruSoDienThoaiHienTai(string MaNguoiDung, string soDienThoai);
        bool ValidateTrungCCCDTrongHeThongTruCCCDHienTai(string MaNguoiDung, string cccd);

        bool ValidateThoiGianTrongLichHoc(DateTime thoiGianBatDau);
        bool ValidateTrungLichHocTruIdDangTarget(DateTime thoiGianBatDau, string MaLop, string MaHocKyBlock, string MaMonHoc, string MaPhong);
    }
}

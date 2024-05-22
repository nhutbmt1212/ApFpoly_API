namespace ApFpoly_API.Services.Interfaces
{
    public interface IValidateDependency
    {
        bool KiemTraTrungEmailTrongHeThong(string email);
        bool KiemTraTrungSoDienThoaiTrongHeThong(string soDienThoai);
        bool KiemTraTrungCCCDTrongHeThong(string cccd);

        bool ValidateTrungEmailTrongHeThongTruEmailHienTai(string MaNguoiDung,string email);
        bool ValidateTrungSoDienThoaiTrongHeThongTruSoDienThoaiHienTai(string MaNguoiDung, string soDienThoai);
        bool ValidateTrungCCCDTrongHeThongTruCCCDHienTai(string MaNguoiDung, string cccd);

    }
}

using ApFpoly_API.Model;

namespace ApFpoly_API.Services.Interfaces
{
    public interface IDiemDanhDependency
    {
        Task<IEnumerable<DiemDanh>> LuuDiemDanh(List<DiemDanh> diemDanhs);
        Task<IEnumerable<DiemDanh>> LayDiemDanhTuMaLichHoc(string MaLichHoc);
        Task<IEnumerable<DiemDanh>> SuaDiemDanh(List<DiemDanh> diemDanhs);
        Task<DiemDanh> KiemTraDiemDanhChoSinhVien(string MaSinhVien, string MaLichHoc);
    }
}

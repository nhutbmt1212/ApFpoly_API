using ApFpoly_API.Model;

namespace ApFpoly_API.Services.Interfaces
{
    public interface IBangDiemDependency
    {
        Task<BangDiem> ThemBangDiem(BangDiem bangDiem);
        Task<IEnumerable<BangDiem>> LayBangDiemTheoIdLop(string MaLop);
        Task<BangDiem> SuaDiemChoSinhVien(string MaLop, string MaSinhVien, string MaMonHoc,double Diem);
        Task<BangDiem> LayDiemTheoSinhVien(string MaLop, string MaSinhVien, string MaMonHoc);
    }
}

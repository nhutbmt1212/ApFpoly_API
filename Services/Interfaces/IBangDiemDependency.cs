using ApFpoly_API.Model;

namespace ApFpoly_API.Services.Interfaces
{
    public interface IBangDiemDependency
    {
        Task<BangDiem> ThemBangDiem(BangDiem bangDiem);
        Task<IEnumerable<BangDiem>> LayBangDiemTheoIdLop(string MaLop);
    }
}

using ApFpoly_API.Model;

namespace ApFpoly_API.Services.Interfaces
{
    public interface IBangDiemDependency
    {
        Task<BangDiem> ThemBangDiem(BangDiem bangDiem);
    }
}

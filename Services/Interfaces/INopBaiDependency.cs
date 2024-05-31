using ApFpoly_API.Model;

namespace ApFpoly_API.Services.Interfaces
{
    public interface INopBaiDependency
    {
        Task<NopBai> ThemNopBai(NopBai nopBai);
    }
}

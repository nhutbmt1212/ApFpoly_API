using ApFpoly_API.Data;
using ApFpoly_API.Model;
using ApFpoly_API.Services.Interfaces;

namespace ApFpoly_API.Services.Implementations
{
    public class NopBaiDependency : INopBaiDependency
    {
        private readonly DataContext _db; 
        public NopBaiDependency(DataContext db)
        {
            _db = db;

        }
        public async Task<NopBai> ThemNopBai(NopBai nopBai)
        {
            try
            {
                _db.NopBai.AddAsync(nopBai);
                _db.SaveChangesAsync();
                return nopBai;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }

        }
    }
}

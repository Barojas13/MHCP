using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;

namespace _4_Tesis.DataAccess.Repositories
{
    public class AresRepository :IAresRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public AresRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task SaveAres(Ares ares)
        {
            await _eTLCRMContext.ares.AddRangeAsync(ares);
            await _eTLCRMContext.SaveChangesAsync();
        }
    }
}

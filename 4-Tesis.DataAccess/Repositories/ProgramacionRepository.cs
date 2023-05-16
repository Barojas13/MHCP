using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;

namespace _4_Tesis.DataAccess.Repositories
{
    public class ProgramacionRepository : IProgramacionRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public ProgramacionRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task SaveProgramacion(Programacion programacion)
        {
            try
            {
                await _eTLCRMContext.Programaciones.AddAsync(programacion);
                await _eTLCRMContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}

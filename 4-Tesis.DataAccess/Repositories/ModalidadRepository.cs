using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;
using Microsoft.EntityFrameworkCore;

namespace _4_Tesis.DataAccess.Repositories
{
    public class ModalidadRepository : IModalidadRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public ModalidadRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task<Modalidad> GetModalidadByName(string name)
        {
            Modalidad modalidad = new Modalidad();

            try
            {
                return await _eTLCRMContext.Modalidades.FirstAsync(a => a.nombre_modalidad == name);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task SaveModalidad(Modalidad modalidad)
        {
            await _eTLCRMContext.Modalidades.AddAsync(modalidad);
            await _eTLCRMContext.SaveChangesAsync();
        }
    }
}

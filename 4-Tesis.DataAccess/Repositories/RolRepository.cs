using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;
using Microsoft.EntityFrameworkCore;

namespace _4_Tesis.DataAccess.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public RolRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task<Rol> GetRolByName(string name)
        {
            Rol rol = new Rol();

            try
            {
                var t = await _eTLCRMContext.Roles.Where(a => a.nombre_rol == name).FirstOrDefaultAsync();
                return t;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task SaveRol(Rol rol)
        {
            await _eTLCRMContext.Roles.AddAsync(rol);
            await _eTLCRMContext.SaveChangesAsync();
        }

        public async Task UpdateRol(Rol rol)
        {
            _eTLCRMContext.Roles.Update(rol);
            await _eTLCRMContext.SaveChangesAsync();
        }
    }
}

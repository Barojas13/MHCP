using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Interfaces
{
    public interface IRolRepository
    {
        Task SaveRol(Rol rol);
        Task<Rol> GetRolByName(string name);
        Task UpdateRol(Rol rol);
    }
}

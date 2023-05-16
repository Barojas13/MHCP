using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Interfaces
{
    public interface IModalidadRepository
    {
        Task SaveModalidad(Modalidad modalidad);
        Task<Modalidad> GetModalidadByName(string name);
    }
}

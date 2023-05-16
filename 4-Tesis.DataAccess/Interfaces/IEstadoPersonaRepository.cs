using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Interfaces
{
    public interface IEstadoPersonaRepository
    {
        Task SaveEstadoPersona(EstadoPersona estadoPersona);
        Task<EstadoPersona> GetEstadoPersonaByName(string name);
    }
}

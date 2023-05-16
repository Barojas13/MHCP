using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Interfaces
{
    public interface IEstadoActaRepository
    {
        Task SaveEstadoActa(EstadoActa estadoActa);
        Task<EstadoActa> GetEstadoActaByName(string name);
    }
}

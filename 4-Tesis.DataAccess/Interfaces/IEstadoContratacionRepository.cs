using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Interfaces
{
    public interface IEstadoContratacionRepository
    {
        Task SaveEstadoContratacion(EstadoContratacion estadoContratacion);
        Task<EstadoContratacion> GetEstadoContratacionByName(string name);
    }
}

using _4_Tesis.DataAccess.DataBaseObjects;

namespace _3_Tesis.Domain.Interfaces
{
    public interface IEstadoActaCore
    {
        Task SaveEstadoActa(EstadoActa estadoActa);
    }
}

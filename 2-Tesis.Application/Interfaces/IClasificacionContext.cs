using _4_Tesis.DataAccess.DataBaseObjects;

namespace _2_Tesis.Application.Interfaces
{
    public interface IClasificacionContext
    {
        Task SaveClasificacion(Clasificacion clasificacion);
    }
}

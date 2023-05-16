using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Interfaces
{
    public interface ICumplimientoRepository
    {
        Task SaveCumplimiento(Cumplimiento cumplimiento);
        Task<Cumplimiento> GetCumplimientoByName(string name);
    }
}

using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Manager.Cumplimiento.Interfaces
{
    public interface ICumplimientoRepositoryManager
    {
        Task SaveCumplimiento(DataBaseObjects.Cumplimiento cumplimiento);
        Task<DataBaseObjects.Cumplimiento> GetCumplimientoByName(string name);
    }
}

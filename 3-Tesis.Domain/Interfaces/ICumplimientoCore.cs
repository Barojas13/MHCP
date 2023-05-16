using _4_Tesis.DataAccess.DataBaseObjects;

namespace _3_Tesis.Domain.Interfaces
{
    public interface ICumplimientoCore
    {
        Task SaveCumplimiento(Cumplimiento cumplimiento);
    }
}

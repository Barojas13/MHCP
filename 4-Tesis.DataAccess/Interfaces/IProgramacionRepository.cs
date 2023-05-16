using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Interfaces
{
    public interface IProgramacionRepository
    {
        Task SaveProgramacion(Programacion programacion);
    }
}

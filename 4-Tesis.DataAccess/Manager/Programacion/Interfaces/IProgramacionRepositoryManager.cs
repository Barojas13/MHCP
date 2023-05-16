namespace _4_Tesis.DataAccess.Manager.Programacion.Interfaces
{
    public interface IProgramacionRepositoryManager
    {
        Task SaveProgramacion(DataBaseObjects.Programacion programacion);
    }
}

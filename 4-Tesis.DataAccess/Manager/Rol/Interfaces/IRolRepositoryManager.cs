namespace _4_Tesis.DataAccess.Manager.Rol.Interfaces
{
    public interface IRolRepositoryManager
    {
        Task SaveRol(DataBaseObjects.Rol rol);
        Task<DataBaseObjects.Rol> GetRolByName(string name);
        Task UpdateRol(DataBaseObjects.Rol rol);
    }
}

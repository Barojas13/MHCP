using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Interfaces
{
    public interface IAresRepository
    {
        Task SaveAres(Ares ares);
    }
}

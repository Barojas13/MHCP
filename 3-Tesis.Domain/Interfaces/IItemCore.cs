using _4_Tesis.DataAccess.DataBaseObjects;

namespace _3_Tesis.Domain.Interfaces
{
    public interface IItemCore
    {
        Task SaveItem(Item item);
    }
}

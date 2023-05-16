using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Interfaces
{
    public interface IItemRepository
    {
        Task SaveItem(Item item);
        Task<Item> GetItemByName(string name);
    }
}

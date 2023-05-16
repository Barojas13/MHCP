namespace _4_Tesis.DataAccess.Manager.Item.Interfaces
{
    public interface IItemRepositoryManager
    {
        Task SaveItem(DataBaseObjects.Item item);
        Task<DataBaseObjects.Item> GetItemByName(string name);
    }
}

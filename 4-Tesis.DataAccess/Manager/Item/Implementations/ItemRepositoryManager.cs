using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.Item.Interfaces;
using _4_Tesis.DataAccess.Repositories;

namespace _4_Tesis.DataAccess.Manager.Item.Implementations
{
    public class ItemRepositoryManager : IItemRepositoryManager
    {
        private static IItemRepository _itemRepository;

        public static IItemRepository ItemRepository
        {
            get
            {
                if (_itemRepository == null)
                {
                    _itemRepository = new ItemRepository();
                }
                return _itemRepository;
            }
            set { _itemRepository = value; }
        }

        public async Task<DataBaseObjects.Item> GetItemByName(string name)
        {
            return await ItemRepository.GetItemByName(name);
        }

        public async Task SaveItem(DataBaseObjects.Item item)
        {
            await ItemRepository.SaveItem(item);
        }
    }
}

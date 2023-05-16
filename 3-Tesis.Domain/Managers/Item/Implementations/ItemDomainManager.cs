using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.Item.Interfaces;

namespace _3_Tesis.Domain.Managers.Item.Implementations
{
    public class ItemDomainManager :IItemDomainManager
    {
        private static IItemCore _itemCore;

        public static IItemCore ItemCore
        {
            get
            {
                if (_itemCore == null)
                {
                    _itemCore = new ItemCore();
                }
                return _itemCore;
            }
            set { _itemCore = value; }
        }

        public async Task SaveItem(_4_Tesis.DataAccess.DataBaseObjects.Item item)
        {
            await _itemCore.SaveItem(item);
        }
    }
}

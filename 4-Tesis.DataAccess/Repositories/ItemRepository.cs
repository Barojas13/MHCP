using _4_Tesis.DataAccess.DataBaseObjects;
using _4_Tesis.DataAccess.Interfaces;
using _4_Tesis.DataAccess.Manager.ConnectionDataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;

namespace _4_Tesis.DataAccess.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ETLCRMContext _eTLCRMContext;

        public ItemRepository()
        {
            _eTLCRMContext = SqlServerContext.ETLCRMContext;
        }

        public async Task<Item> GetItemByName(string name)
        {
            Item item = new Item();

            try
            {
                return await _eTLCRMContext.items.FirstAsync(a => a.nombre_item == name);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task SaveItem(Item item)
        {
            await _eTLCRMContext.AddAsync(item);
            await _eTLCRMContext.SaveChangesAsync();
        }
    }
}

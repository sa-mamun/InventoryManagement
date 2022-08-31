using InventoryManagement.Web.Contexts;
using InventoryManagement.Web.Entities;

namespace InventoryManagement.Web.Repositories
{
    public class ItemRepository : BaseRepository<Item, long, InventoryDbContext>, IItemRepository
    {
        public ItemRepository(InventoryDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}

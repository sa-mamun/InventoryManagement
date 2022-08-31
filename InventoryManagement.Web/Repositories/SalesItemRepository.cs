using InventoryManagement.Web.Contexts;
using InventoryManagement.Web.Entities;

namespace InventoryManagement.Web.Repositories
{
    public class SalesItemRepository : BaseRepository<SalesItem, long, InventoryDbContext>, ISalesItemRepository
    {
        public SalesItemRepository(InventoryDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}

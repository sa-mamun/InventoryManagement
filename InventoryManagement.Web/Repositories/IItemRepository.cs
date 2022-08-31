using InventoryManagement.Web.Contexts;
using InventoryManagement.Web.Entities;

namespace InventoryManagement.Web.Repositories
{
    public interface IItemRepository : IBaseRepository<Item, long, InventoryDbContext>
    {
    }
}

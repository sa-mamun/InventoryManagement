using InventoryManagement.Web.Contexts;
using InventoryManagement.Web.Entities;

namespace InventoryManagement.Web.Repositories
{
    public interface ISalesItemRepository : IBaseRepository<SalesItem, long, InventoryDbContext>
    {
    }
}

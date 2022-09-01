using InventoryManagement.Web.Contexts;
using InventoryManagement.Web.Entities;

namespace InventoryManagement.Web.Repositories
{
    public interface IDistrictRepository : IBaseRepository<District, long, InventoryDbContext>
    {
    }
}

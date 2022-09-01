using InventoryManagement.Web.Contexts;
using InventoryManagement.Web.Entities;

namespace InventoryManagement.Web.Repositories
{
    public class DistrictRepository : BaseRepository<District, long, InventoryDbContext>, IDistrictRepository
    {
        public DistrictRepository(InventoryDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}

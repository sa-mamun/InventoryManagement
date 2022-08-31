using InventoryManagement.Web.Contexts;
using InventoryManagement.Web.Entities;

namespace InventoryManagement.Web.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, long, InventoryDbContext>, ICustomerRepository
    {
        public CustomerRepository(InventoryDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}

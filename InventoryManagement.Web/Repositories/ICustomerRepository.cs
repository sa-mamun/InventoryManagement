using InventoryManagement.Web.Contexts;
using InventoryManagement.Web.Entities;

namespace InventoryManagement.Web.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer, long, InventoryDbContext>
    {
    }
}

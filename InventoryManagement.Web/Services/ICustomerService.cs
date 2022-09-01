using InventoryManagement.Web.Entities;

namespace InventoryManagement.Web.Services
{
    public interface ICustomerService
    {
        void Create(Customer customer);

        (IList<Customer> Customers, int Total, int TotalFilter) LoadAll();
    }
}

using InventoryManagement.Web.Entities;
using InventoryManagement.Web.Repositories;

namespace InventoryManagement.Web.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Create(Customer customer)
        {
            _customerRepository.Add(customer);
            _customerRepository.SaveChanges();
        }

        public (IList<Customer> Customers, int Total, int TotalFilter) LoadAll()
        {
            return _customerRepository.Get<Customer>(x => x, x => x.Status == EntityStatus.Active, null, null, 1, 10, true);
        }
    }
}

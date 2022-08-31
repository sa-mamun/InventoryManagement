using InventoryManagement.Web.Entities;
using InventoryManagement.Web.Repositories;

namespace InventoryManagement.Web.Services
{
    public class SalesItemService : ISalesItemService
    {
        private readonly ISalesItemRepository _salesItemRepository;

        public SalesItemService(ISalesItemRepository salesItemRepository)
        {
            _salesItemRepository = salesItemRepository;
        }

        public void Create(SalesItem salesItem)
        {
            _salesItemRepository.Add(salesItem);
            _salesItemRepository.SaveChanges();
        }
    }
}

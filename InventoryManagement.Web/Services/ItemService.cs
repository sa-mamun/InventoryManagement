using InventoryManagement.Web.Entities;
using InventoryManagement.Web.Repositories;

namespace InventoryManagement.Web.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public void Create(Item item)
        {
            _itemRepository.Add(item);
            _itemRepository.SaveChanges();
        }
    }
}

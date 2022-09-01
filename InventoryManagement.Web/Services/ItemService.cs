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

        public (IList<Item> Items, int Total, int TotalFilter) LoadAll()
        {
            return _itemRepository.Get<Item>(x => x, x => x.Status == EntityStatus.Active, null, null, 1, 10, true);
        }
    }
}

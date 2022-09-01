using InventoryManagement.Web.Entities;

namespace InventoryManagement.Web.Services
{
    public interface IItemService
    {
        void Create(Item item);
        (IList<Item> Items, int Total, int TotalFilter) LoadAll();
    }
}

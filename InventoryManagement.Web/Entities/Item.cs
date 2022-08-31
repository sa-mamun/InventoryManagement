using static InventoryManagement.Web.Enums.InventoryEnums;

namespace InventoryManagement.Web.Entities
{
    public class Item : AuditableEntity<long>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ItemGroup ItemGroup { get; set; }
    }
}

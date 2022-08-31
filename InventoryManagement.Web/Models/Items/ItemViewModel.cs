using static InventoryManagement.Web.Enums.InventoryEnums;

namespace InventoryManagement.Web.Models.Items
{
    public class ItemViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int ItemGroup { get; set; }
        public int Status { get; set; }
    }
}

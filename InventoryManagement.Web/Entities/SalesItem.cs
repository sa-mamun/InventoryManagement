using static InventoryManagement.Web.Enums.InventoryEnums;

namespace InventoryManagement.Web.Entities
{
    public class SalesItem : AuditableEntity<long>
    {
        public long InvoiceNumber { get; set; }
        public ItemGroup ItemGroup { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
        public long ItemId { get; set; }
        public long CustomerId { get; set; }
        public Item Item { get; set; }
        public Customer Customer { get; set; }
    }
}

namespace InventoryManagement.Web.Entities
{
    public abstract class AuditableEntity<TKey> : BaseEntity<TKey>
    {
        public AuditableEntity()
        {
            CreationDate = DateTime.Now;
            Status = EntityStatus.Active;
        }

        public string CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int Status { get; set; }
    }
}

using InventoryManagement.Web.Entities;
using static InventoryManagement.Web.Enums.InventoryEnums;

namespace InventoryManagement.Web.Models.Items
{
    public class CustomerViewModel
    { 
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public long DistrictId { get; set; }
        public District District { get; set; }        
        public int Status { get; set; }
    }
}

using System.ComponentModel;

namespace InventoryManagement.Web.Enums
{
    public class InventoryEnums
    {
        public enum ItemGroup
        {
            [Description("Studey Materials")]
            StudeyMaterials = 1,
            [Description("Stationary")]
            Stationary = 2,
            [Description("Gift")]
            Gift = 3
        }

        public enum Gender
        {
            [Description("Male")]
            Male = 1,
            [Description("Female")]
            Female = 2,
        }

        public enum Status
        {
            [Description("Active")]
            Active = 1,
            [Description("Inactive")]
            Inactive = -1
        }
    }
}

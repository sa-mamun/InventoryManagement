using InventoryManagement.Web.Entities;

namespace InventoryManagement.Web.Services
{
    public interface IDistrictService
    {
        void Create(District district);
        (IList<District> Districts, int Total, int TotalFilter) LoadAll();
    }
}

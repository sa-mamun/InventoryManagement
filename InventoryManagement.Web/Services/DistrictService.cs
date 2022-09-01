using InventoryManagement.Web.Entities;
using InventoryManagement.Web.Repositories;

namespace InventoryManagement.Web.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;

        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public void Create(District item)
        {
            _districtRepository.Add(item);
            _districtRepository.SaveChanges();
        }

        public (IList<District> Districts, int Total, int TotalFilter) LoadAll()
        {
            return _districtRepository.Get<District>(x => x, x => x.Status == EntityStatus.Active, null, null, 1, 10, true);
        }
    }
}

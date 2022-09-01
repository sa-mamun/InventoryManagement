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
        //public List<District> LoadDistrict(District item)
        //{
        //    _districtRepository.Get(item);
        //    _districtRepository.SaveChanges();
        //}
    }
}

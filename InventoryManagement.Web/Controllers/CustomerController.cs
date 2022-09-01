using InventoryManagement.Web.Entities;
using InventoryManagement.Web.Helper;
using InventoryManagement.Web.Models.Items;
using InventoryManagement.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using static InventoryManagement.Web.Enums.InventoryEnums;

namespace InventoryManagement.Web.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDistrictService _districtService;
        private readonly ICustomerService _customerService;


        public CustomerController(ILogger<HomeController> logger, ICustomerService customerService, IDistrictService districtService)
        {
            _logger = logger;

            _districtService = districtService;
            _customerService = customerService;
        }

        public IActionResult Create()
        {
            try
            {
                var districtList = _districtService.LoadAll();
                List<District> districts = districtList.Districts.ToList();
                ViewBag.District = new SelectList(districts, "Id", "Name");
                ViewBag.Gender = new SelectList(InventoryHelper.LoadEmumToDictionary<Gender>(), "Key", "Value");
                ViewBag.Status = new SelectList(InventoryHelper.LoadEmumToDictionary<Status>(), "Key", "Value");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var item = new Customer
                    {
                        FullName = model.FullName,
                        Mobile = model.Mobile,
                        Email = model.Email,
                        Gender = model.Gender,
                        Address = model.Address, 
                        DistrictId = model.DistrictId,
                        CreateBy = userId,
                        Status = model.Status
                    };

                    _customerService.Create(item);

                    return RedirectToAction(nameof(Create));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return View();
        }
    }
}

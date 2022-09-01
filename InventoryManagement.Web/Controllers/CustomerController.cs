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

        public IActionResult Manage()
        {
            return View();
        }

        public JsonResult ManageAjaxDataTable(int draw, int start, int length)
        {
            var data = new List<object>();
            long recordsTotal = 0;
            long recordsFiltered = 0;
            try
            {
                var districtList = _districtService.LoadAll();
                List<District> districts = districtList.Districts.ToList();

                var items = _customerService.LoadAll();
                recordsFiltered = items.TotalFilter;
                recordsTotal = recordsFiltered;
                int sl = 1 + start;
                foreach (var item in items.Customers)
                {
                    var str = new List<string>();
                    str.Add(sl++.ToString());
                    str.Add(item.FullName);
                    str.Add(item.Mobile);
                    str.Add(item.Email);
                    str.Add(InventoryHelper.GetEmumIdToValue<Gender>((int)item.Gender));
                    str.Add(item.Address);
                    string districtName = districts.Where(x => x.Id.Equals(item.DistrictId)).First().Name;
                    str.Add(districtName);
                    str.Add("-");

                    data.Add(str);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Json(new
            {
                draw = draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                start = start,
                length = length,
                data = data
            });
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

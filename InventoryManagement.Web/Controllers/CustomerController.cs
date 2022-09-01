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
        private readonly IItemService _itemService;
        //private readonly IDistrictService _districtService;


        public CustomerController(ILogger<HomeController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }
        public IActionResult Create()
        {
            try
            {

                ViewBag.District = new SelectList(InventoryHelper.LoadEmumToDictionary<ItemGroup>(), "Key", "Value");
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
        public IActionResult Create(ItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var item = new Item
                    {
                        Name = model.Name,
                        ItemGroup = (ItemGroup)model.ItemGroup,
                        Price = model.Price,
                        CreateBy = userId,
                        Status = model.Status
                    };
                    
                    _itemService.Create(item);

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

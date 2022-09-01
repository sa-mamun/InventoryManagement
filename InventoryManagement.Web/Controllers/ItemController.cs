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
    public class ItemController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService _itemService;

        public ItemController(ILogger<HomeController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
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
                var items = _itemService.LoadAll();
                recordsFiltered = items.TotalFilter;
                recordsTotal = recordsFiltered;
                int sl = 1 + start;
                foreach (var item in items.Items)
                {
                    var str = new List<string>();
                    str.Add(sl++.ToString());
                    str.Add(item.Name);
                    str.Add(InventoryHelper.GetEmumIdToValue<ItemGroup>((int)item.ItemGroup));
                    str.Add(item.Price.ToString());
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
                ViewBag.ItemGroup = new SelectList(InventoryHelper.LoadEmumToDictionary<ItemGroup>(), "Key", "Value");
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
                    ViewBag.ItemGroup = new SelectList(InventoryHelper.LoadEmumToDictionary<ItemGroup>(), "Key", "Value", model.ItemGroup);
                    ViewBag.Status = new SelectList(InventoryHelper.LoadEmumToDictionary<Status>(), "Key", "Value", model.Status);
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

                    return RedirectToAction(nameof(Manage));
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

using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.ItemAgg.Contracts;
using App.Domain.Core.ItemAgg.Dtos;
using App.Domain.Core.ItemAgg.Entities;
using App.Domain.Core.ItemAgg.Enums;
using App.Infra.Db.SqlServer.LocalDb;
using Hw19.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hw19.Controllers
{
    public class ManageItemsController : Controller
    {
        private readonly ILogger<ManageItemsController> _logger;
        private readonly IItemAppService _itemAppService;
        private readonly ICategoryAppService _categoryAppService;
        public ManageItemsController(IItemAppService itemAppService, ICategoryAppService categoryAppService)
        {
            _itemAppService = itemAppService;
            _categoryAppService = categoryAppService;
        }
        public IActionResult Index(SearchItemDto searchItem, OrderItemsEnum orderItems = OrderItemsEnum.None)
        {
            var items = _itemAppService.UserItems(LocalStorage.CurrentUser.Id, searchItem, orderItems)
                .Data ?? new List<GetUserItemsDto>();
            var model = new GetAndSearchItemsViewModel
            {
                userItemsDtos = items,
                searchItemDto = searchItem ?? new SearchItemDto()
            };
            ViewBag.OrderItemsEnum = Enum.GetValues(typeof(OrderItemsEnum));
            return View(model);
        }
        public IActionResult AddItem()
        {
            var categories = _categoryAppService.GetAllCategories();
            var model = new AddItemViewModel
            {
                cats = categories.Data,
                itemDto = new AddItemDto()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult SaveItem(AddItemDto itemDto) 
        {
            _itemAppService.AddItem(itemDto);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteItem(int itemId)
        {
            _itemAppService.DeleteItem(itemId);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult EditItem(int itemId)
        {
            _itemAppService.ChangeIsDone(itemId);
            return RedirectToAction("Index");
        }
        
    }
}


using App.Domain.Core.General.Dto;
using App.Domain.Core.ItemAgg.Contracts;
using App.Domain.Core.ItemAgg.Dtos;
using App.Domain.Core.ItemAgg.Enums;

namespace App.Domain.AppServices;

public class ItemAppService : IItemAppService
{
    private readonly IItemService _itemService;
    public ItemAppService(IItemService itemService)
    {
        _itemService = itemService;
    }

    public ResultDto<bool> AddItem(AddItemDto itemDto)
    {
        return _itemService.AddItem(itemDto);
    }

    public ResultDto<bool> ChangeIsDone(int itemId)
    {
        return _itemService.ChangeIsDone(itemId);
    }

    public ResultDto<bool> DeleteItem(int itemId)
    {
        return _itemService.DeleteItem(itemId);
    }

    public ResultDto<List<GetUserItemsDto>> UserItems(int userId, SearchItemDto searchItem, OrderItemsEnum orderItems)
    {
        return _itemService.UserItems(userId, searchItem, orderItems);
    }

}

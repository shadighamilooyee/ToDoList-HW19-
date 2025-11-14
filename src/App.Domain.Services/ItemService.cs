
using App.Domain.Core.General.Dto;
using App.Domain.Core.ItemAgg.Contracts;
using App.Domain.Core.ItemAgg.Dtos;
using App.Domain.Core.ItemAgg.Enums;
using System.Linq;
using System.Net.WebSockets;

namespace App.Domain.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    public ResultDto<bool> AddItem(AddItemDto itemDto)
    {
        _itemRepository.AddItem(itemDto);
        return new ResultDto<bool> { IsSucceed = true }; 
    }
    public ResultDto<bool> ChangeIsDone(int itemId)
    {
        _itemRepository.ChangeIsDone(itemId);
        return new ResultDto<bool> { IsSucceed = true };
    }
    public ResultDto<bool> DeleteItem(int itemId)
    {
        _itemRepository.DeleteItem(itemId);
        return new ResultDto<bool> { IsSucceed = true };
    }

    public ResultDto<List<GetUserItemsDto>> UserItems(int userId, SearchItemDto searchItem, OrderItemsEnum orderItems)
    {
        var items = _itemRepository.UserItems(userId, searchItem, orderItems);
        return new ResultDto<List<GetUserItemsDto>> { IsSucceed = true, Data = items };
    }
    
}

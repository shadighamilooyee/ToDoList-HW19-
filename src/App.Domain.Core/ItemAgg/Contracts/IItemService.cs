
using App.Domain.Core.General.Dto;
using App.Domain.Core.ItemAgg.Dtos;
using App.Domain.Core.ItemAgg.Enums;

namespace App.Domain.Core.ItemAgg.Contracts;

public interface IItemService
{
    ResultDto<List<GetUserItemsDto>> UserItems(int userId, SearchItemDto searchItem, OrderItemsEnum orderItems);
    ResultDto<bool> AddItem(AddItemDto itemDto);
    ResultDto<bool> ChangeIsDone(int itemId);
    ResultDto<bool> DeleteItem(int itemId);
}

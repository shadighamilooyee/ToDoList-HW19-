
using App.Domain.Core.ItemAgg.Dtos;
using App.Domain.Core.ItemAgg.Enums;

namespace App.Domain.Core.ItemAgg.Contracts;

public interface IItemRepository
{
    List<GetUserItemsDto> UserItems(int userId, SearchItemDto searchItem, OrderItemsEnum orderItems);
    void AddItem(AddItemDto itemDto);
    void ChangeIsDone(int itemId);
    void DeleteItem(int itemId);
}

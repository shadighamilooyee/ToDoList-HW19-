
using App.Domain.Core.ItemAgg.Dtos;
using App.Domain.Core.ItemAgg.Enums;

namespace App.Domain.Core.ItemAgg.Contracts;

public interface IItemRepository
{
    IQueryable<GetUserItemsDto> UserItems(int userId);
    void AddItem(AddItemDto itemDto);
    void ChangeIsDone(int itemId);
    void DeleteItem(int itemId);
}

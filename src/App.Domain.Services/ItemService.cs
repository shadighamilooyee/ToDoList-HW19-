
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
        var queryable = _itemRepository.UserItems(userId);
        queryable = SearchItem(queryable, searchItem);
        queryable = OrderItem(queryable, orderItems);
        var result = queryable.ToList()?? new List<GetUserItemsDto>();
        return new ResultDto<List<GetUserItemsDto>> { IsSucceed = true, Data = result };
    }
    private IQueryable<GetUserItemsDto> SearchItem(IQueryable<GetUserItemsDto> queryable, SearchItemDto searchItem)
    {
        if (searchItem.SearchedTitle != null)
        {
            return queryable.Where(i => i.Title.ToLower().Contains(searchItem.SearchedTitle.ToLower()));
        }
        if (searchItem.SearchedCategory != null)
        {
            return queryable.Where(i => i.CategoryName.ToLower().Contains(searchItem.SearchedCategory.ToLower()));
        }
        return queryable;
    }
    private IQueryable<GetUserItemsDto> OrderItem(IQueryable<GetUserItemsDto> queryable, OrderItemsEnum orderItems)
    {
        switch (orderItems)
        {
            case OrderItemsEnum.Title:
                return queryable.OrderBy(i => i.Title);
            case OrderItemsEnum.DueDate:
                return queryable.OrderBy(i => i.DueDate);
            case OrderItemsEnum.IsDone:
                return queryable.OrderBy(i => i.IsDone);
            default:
                return queryable;
        }
    }
}

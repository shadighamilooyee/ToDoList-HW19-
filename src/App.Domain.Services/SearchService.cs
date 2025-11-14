
using App.Domain.Core.ItemAgg.Contracts;
using App.Domain.Core.ItemAgg.Dtos;
using App.Domain.Core.ItemAgg.Enums;

namespace App.Domain.Services;

public class SearchService : ISearchService
{
    public IQueryable<GetUserItemsDto> SearchItem(IQueryable<GetUserItemsDto> queryable, SearchItemDto searchItem)
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
    public IQueryable<GetUserItemsDto> OrderItem(IQueryable<GetUserItemsDto> queryable, OrderItemsEnum orderItems)
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

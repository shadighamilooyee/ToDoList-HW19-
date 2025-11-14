
using App.Domain.Core.ItemAgg.Dtos;
using App.Domain.Core.ItemAgg.Enums;

namespace App.Domain.Core.ItemAgg.Contracts;

public interface ISearchService
{
    IQueryable<GetUserItemsDto> SearchItem(IQueryable<GetUserItemsDto> queryable, SearchItemDto searchItem);
    IQueryable<GetUserItemsDto> OrderItem(IQueryable<GetUserItemsDto> queryable, OrderItemsEnum orderItems);
}

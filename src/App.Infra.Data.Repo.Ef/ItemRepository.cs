
using App.Domain.Core.ItemAgg.Contracts;
using App.Domain.Core.ItemAgg.Dtos;
using App.Domain.Core.ItemAgg.Entities;
using App.Domain.Core.ItemAgg.Enums;
using App.Domain.Core.UserAgg.Dtos;
using App.Domain.Core.UserAgg.Entities;
using App.Domain.Services;
using App.Infra.Db.SqlServer;
using App.Infra.Db.SqlServer.LocalDb;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repo.Ef;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _dbContext;
    private readonly ISearchService _searchService;
    public ItemRepository(AppDbContext dbContext, ISearchService searchService)
    {
        _dbContext = dbContext;
        _searchService = searchService;
    }
    public List<GetUserItemsDto> UserItems(int userId, SearchItemDto searchItem, OrderItemsEnum orderItems)
    {
        var queryable = _dbContext.Items
            .Where(i => i.UserId == userId)
            .Include(i => i.Category)
            .Select(i => new GetUserItemsDto
            {
                Id = i.Id,
                Title = i.Title,
                Description = i.Description,
                DueDate = i.DueDate,
                CategoryName = i.Category.Name,
                IsDone = i.IsDone
            });
        queryable = _searchService.SearchItem(queryable, searchItem);
        queryable = _searchService.OrderItem(queryable, orderItems);

        return queryable.ToList() ?? new List<GetUserItemsDto>();
    }
    public void AddItem(AddItemDto itemDto)
    {
        var item = new Item
        {
            Title = itemDto.Title,
            CategoryId = itemDto.CategoryId,
            UserId = LocalStorage.CurrentUser.Id,
            DueDate= itemDto.DueDate,
            CreatedAt = DateTime.Now
        };
        _dbContext.Items.Add(item);
        _dbContext.SaveChanges();
    }
    public void ChangeIsDone(int itemId)
    {
        _dbContext.Items
            .Where(i => i.Id == itemId)
            .ExecuteUpdate(setters => setters
            .SetProperty(i => i.IsDone, true));
    }
    public void DeleteItem(int itemId)
    {
        _dbContext.Items
            .Where(i => i.Id == itemId)
            .ExecuteDelete();
    }
}

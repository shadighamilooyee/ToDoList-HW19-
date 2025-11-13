
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
    public ItemRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IQueryable<GetUserItemsDto> UserItems(int userId)
    {
        return _dbContext.Items
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


using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Infra.Db.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repo.Ef;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;
    public CategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<GetCategoriesDto> GetAllCategories()
    {
        return _dbContext.Categories
            .AsNoTracking()
            .Select(c => new GetCategoriesDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
    }
}

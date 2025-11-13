
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.General.Dto;

namespace App.Domain.AppServices;

public class CategoryAppService : ICategoryAppService
{
    private readonly ICategoryService _categoryService;
    public CategoryAppService(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public ResultDto<List<GetCategoriesDto>> GetAllCategories()
    {
        return _categoryService.GetAllCategories();
    }
}

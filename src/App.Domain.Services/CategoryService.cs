
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.General.Dto;

namespace App.Domain.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public ResultDto<List<GetCategoriesDto>> GetAllCategories()
    {
        var categories = _categoryRepository.GetAllCategories();
        return new ResultDto<List<GetCategoriesDto>> { IsSucceed = true, Data = categories };
    }
}

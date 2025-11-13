
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.General.Dto;

namespace App.Domain.Core.CategoryAgg.Contracts;

public interface ICategoryService
{
    ResultDto<List<GetCategoriesDto>> GetAllCategories();
}


using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.General.Dto;

namespace App.Domain.Core.CategoryAgg.Contracts;

public interface ICategoryAppService
{
    ResultDto<List<GetCategoriesDto>> GetAllCategories();
}

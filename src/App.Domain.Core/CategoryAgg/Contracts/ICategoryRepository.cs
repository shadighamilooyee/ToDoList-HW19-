
using App.Domain.Core.CategoryAgg.Dtos;

namespace App.Domain.Core.CategoryAgg.Contracts;

public interface ICategoryRepository
{
    List<GetCategoriesDto> GetAllCategories();
}

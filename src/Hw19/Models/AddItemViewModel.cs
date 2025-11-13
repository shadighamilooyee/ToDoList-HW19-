using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.ItemAgg.Dtos;

namespace Hw19.Models;

public class AddItemViewModel
{
    public List<GetCategoriesDto> cats { get; set; }
    public AddItemDto itemDto { get; set; }
}


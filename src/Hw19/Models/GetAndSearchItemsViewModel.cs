using App.Domain.Core.ItemAgg.Dtos;

namespace Hw19.Models;

public class GetAndSearchItemsViewModel
{
    public SearchItemDto? searchItemDto { get; set; }
    public List<GetUserItemsDto>? userItemsDtos { get; set; }
}

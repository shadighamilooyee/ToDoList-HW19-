
using App.Domain.Core.CategoryAgg.Entities;

namespace App.Domain.Core.ItemAgg.Dtos;

public class GetUserItemsDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsDone { get; set; }
    public DateTime DueDate { get; set; }
    public string CategoryName { get; set; }
}

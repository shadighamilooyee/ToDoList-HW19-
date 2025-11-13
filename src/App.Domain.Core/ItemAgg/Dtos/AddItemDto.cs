
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.UserAgg.Entities;

namespace App.Domain.Core.ItemAgg.Dtos;

public class AddItemDto
{
    public string Title { get; set; }
    public DateTime DueDate { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public int UserId { get; set; }
}

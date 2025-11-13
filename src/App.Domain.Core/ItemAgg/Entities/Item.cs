
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.UserAgg.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Core.ItemAgg.Entities;

public class Item
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsDone { get; set; }
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
}

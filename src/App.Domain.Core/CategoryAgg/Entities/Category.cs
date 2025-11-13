
using App.Domain.Core.ItemAgg.Entities;

namespace App.Domain.Core.CategoryAgg.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Item>? Items { get; set; }
}

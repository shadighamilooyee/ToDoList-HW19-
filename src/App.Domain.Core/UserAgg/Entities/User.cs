
using App.Domain.Core.ItemAgg.Entities;

namespace App.Domain.Core.UserAgg.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Item>? Items { get; set; }
}

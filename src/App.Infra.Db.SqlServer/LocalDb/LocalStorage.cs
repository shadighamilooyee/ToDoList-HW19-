
using App.Domain.Core.UserAgg.Entities;

namespace App.Infra.Db.SqlServer.LocalDb;

public static class LocalStorage
{
    public static User? CurrentUser { get; set; }
}


using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.ItemAgg.Entities;
using App.Domain.Core.UserAgg.Entities;
using App.Infra.Db.SqlServer.Configurations;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Db.SqlServer;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=DESKTOP-Q3HHNR8\SQLEXPRESS;Database=ToDoList;Integrated Security=true;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}

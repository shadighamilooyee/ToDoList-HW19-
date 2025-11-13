
using App.Domain.Core.ItemAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Db.SqlServer.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.Property(i=>i.Title).HasMaxLength(100).IsRequired();
        builder.Property(i => i.CreatedAt).HasDefaultValueSql("GETDATE()");       
    }
}

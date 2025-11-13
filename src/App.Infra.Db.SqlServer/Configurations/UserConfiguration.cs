
using App.Domain.Core.UserAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Db.SqlServer.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Username).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Password).HasMaxLength(100).IsRequired();

        builder.HasMany(u => u.Items)
            .WithOne(i => i.User)
            .HasForeignKey(i => i.UserId);

        builder.HasData(
            new User { Username = "Shadi", Password = "AQAAAAIAAYagAAAAEFqYnmJqzy7iNcLb9XTgiGJuC2YhqfQuAbQ2jv4N22x/b3rPraCE8PtuOgUHUZKr/w==", Id = 1},
            new User { Username = "Yasaman", Password = "AQAAAAIAAYagAAAAEFqYnmJqzy7iNcLb9XTgiGJuC2YhqfQuAbQ2jv4N22x/b3rPraCE8PtuOgUHUZKr/w==", Id = 2 },
            new User { Username = "Sara", Password = "AQAAAAIAAYagAAAAEFqYnmJqzy7iNcLb9XTgiGJuC2YhqfQuAbQ2jv4N22x/b3rPraCE8PtuOgUHUZKr/w==", Id = 3 }
            );
    }
}

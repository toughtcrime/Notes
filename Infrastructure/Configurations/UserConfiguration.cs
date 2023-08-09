using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        
        
        builder.HasMany(x => x.Notes)
               .WithOne(x => x.Owner)
               .HasForeignKey(x => x.OwnerId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(x => x.Username);
        builder.HasIndex(x => x.Email);
        builder.HasIndex(x => x.Id);

    }
}
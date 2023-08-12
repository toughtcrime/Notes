using BCrypt.Net;
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

        builder.HasData(new User
        {
            Id = 1,
            Username = "JackBiba",
            Email = "text@mail.com",
            Firstname = "Jack",
            Lastname = "BIba",
            BirthDay = new DateTime(2000, 10, 17),
            HashedPassword = BCrypt.Net.BCrypt.HashPassword("test12312312312")
        });

        builder.HasData(new User
        {
            Id = 2,
            Username = "JackBoba",
            Email = "text@mail.com",
            Firstname = "Jack",
            Lastname = "Boba",
            BirthDay = new DateTime(2000, 10, 17),
            HashedPassword = BCrypt.Net.BCrypt.HashPassword("bobaORbiba?")
        });
    }
}
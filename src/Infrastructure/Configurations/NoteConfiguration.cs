using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configurations;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Content);
        builder.HasIndex(x => x.Title);
        builder.HasIndex(x => x.Id);

        builder.HasData(new Note
        {
            Id = 1,
            Content = "Puncake recipe is...",
            Title = "Puncake recipe",
            OwnerId = 2
        });
        builder.HasData(new Note
        {
            Id = 2,
            Content = "u know, I'm not telling anything...",
            Title = "How to find a job as junior .NET developer",
            OwnerId = 2
        });
        builder.HasData(new Note
        {
            Id = 3,
            Content = "1. Use cv builder. 2. Write short info about you. 3. Write info about your skills and pet projects",
            Title = "How to make good CV",
            OwnerId = 1
        });

        builder.HasData(new Note
        {
            Id = 4,
            Content = "Pizza recipe is..................",
            Title = "Pizza recipe from my mom",
            OwnerId = 1,
        });

    }
}
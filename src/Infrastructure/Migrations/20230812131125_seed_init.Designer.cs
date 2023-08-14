﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20230812131125_seed_init")]
    partial class seed_init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Note", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Content");

                    b.HasIndex("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("Title");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Content = "Puncake recipe is...",
                            OwnerId = 2L,
                            Title = "Puncake recipe"
                        },
                        new
                        {
                            Id = 2L,
                            Content = "u know, I'm not telling anything...",
                            OwnerId = 2L,
                            Title = "How to find a job as junior .NET developer"
                        },
                        new
                        {
                            Id = 3L,
                            Content = "1. Use cv builder. 2. Write short info about you. 3. Write info about your skills and pet projects",
                            OwnerId = 1L,
                            Title = "How to make good CV"
                        },
                        new
                        {
                            Id = 4L,
                            Content = "Pizza recipe is..................",
                            OwnerId = 1L,
                            Title = "Pizza recipe from my mom"
                        });
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("Id");

                    b.HasIndex("Username");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BirthDay = new DateTime(2000, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "text@mail.com",
                            Firstname = "Jack",
                            HashedPassword = "$2a$11$pWyoa2Oavffzf312ja0/7.nGY1PjGLtjPOzUrdKxiaZ1Pqv1teUEG",
                            Lastname = "BIba",
                            RegistrationDate = new DateTime(2023, 8, 12, 13, 11, 24, 383, DateTimeKind.Utc).AddTicks(1872),
                            Role = 0,
                            Username = "JackBiba"
                        },
                        new
                        {
                            Id = 2L,
                            BirthDay = new DateTime(2000, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "text@mail.com",
                            Firstname = "Jack",
                            HashedPassword = "$2a$11$0K9VUmVAXpn0rMJBaYDaq.ZSPC5k0srx8JzdMDl/efBiEjyl8Ur6e",
                            Lastname = "Boba",
                            RegistrationDate = new DateTime(2023, 8, 12, 13, 11, 24, 631, DateTimeKind.Utc).AddTicks(7937),
                            Role = 0,
                            Username = "JackBoba"
                        });
                });

            modelBuilder.Entity("Domain.Models.Note", b =>
                {
                    b.HasOne("Domain.Models.User", "Owner")
                        .WithMany("Notes")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}

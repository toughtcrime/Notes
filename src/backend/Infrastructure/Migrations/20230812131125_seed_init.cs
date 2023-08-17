using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed_init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    HashedPassword = table.Column<string>(type: "text", nullable: false),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDay", "Email", "Firstname", "HashedPassword", "Lastname", "RegistrationDate", "Role", "Username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2000, 10, 17, 0, 0, 0, 0, DateTimeKind.Utc), "text@mail.com", "Jack", "$2a$11$pWyoa2Oavffzf312ja0/7.nGY1PjGLtjPOzUrdKxiaZ1Pqv1teUEG", "BIba", new DateTime(2023, 8, 12, 13, 11, 24, 383, DateTimeKind.Utc).AddTicks(1872), 0, "JackBiba" },
                    { 2L, new DateTime(2000, 10, 17, 0, 0, 0, 0, DateTimeKind.Utc), "text@mail.com", "Jack", "$2a$11$0K9VUmVAXpn0rMJBaYDaq.ZSPC5k0srx8JzdMDl/efBiEjyl8Ur6e", "Boba", new DateTime(2023, 8, 12, 13, 11, 24, 631, DateTimeKind.Utc).AddTicks(7937), 0, "JackBoba" }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1L, "Puncake recipe is...", 2L, "Puncake recipe" },
                    { 2L, "u know, I'm not telling anything...", 2L, "How to find a job as junior .NET developer" },
                    { 3L, "1. Use cv builder. 2. Write short info about you. 3. Write info about your skills and pet projects", 1L, "How to make good CV" },
                    { 4L, "Pizza recipe is..................", 1L, "Pizza recipe from my mom" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Content",
                table: "Notes",
                column: "Content");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Id",
                table: "Notes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_OwnerId",
                table: "Notes",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Title",
                table: "Notes",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

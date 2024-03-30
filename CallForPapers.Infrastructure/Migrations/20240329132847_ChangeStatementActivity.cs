using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CallForPapers.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStatementActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Statements");

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityId",
                table: "Statements",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("8ba77d07-e26e-48a4-8a52-f344dcb1b5a1"), "Доклад, 35-45 минут", "Report" },
                    { new Guid("9adc585d-de90-4931-bb9e-5741d0c74746"), "Мастеркласс, 1-2 часа", "Masterclass" },
                    { new Guid("babd3aaa-6cab-46e3-a0d9-2a69d134da8c"), "Дискуссия / круглый стол, 40-50 минут", "Discussion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statements_ActivityId",
                table: "Statements",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statements_Activities_ActivityId",
                table: "Statements",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statements_Activities_ActivityId",
                table: "Statements");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Statements_ActivityId",
                table: "Statements");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Statements");

            migrationBuilder.AddColumn<int>(
                name: "Activity",
                table: "Statements",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

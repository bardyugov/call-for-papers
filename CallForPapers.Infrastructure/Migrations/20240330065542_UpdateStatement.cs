using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CallForPapers.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("8ba77d07-e26e-48a4-8a52-f344dcb1b5a1"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("9adc585d-de90-4931-bb9e-5741d0c74746"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("babd3aaa-6cab-46e3-a0d9-2a69d134da8c"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Statements",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedTime",
                table: "Statements",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1dc51594-8746-4bb9-ae4b-6f953a1e3411"), "Доклад, 35-45 минут", "Report" },
                    { new Guid("4f8d5a07-45cd-4e3d-ab0b-b8c6b286dfb3"), "Мастеркласс, 1-2 часа", "Masterclass" },
                    { new Guid("ce2bc301-8ff0-4d9f-ab40-8e1428b6df2b"), "Дискуссия / круглый стол, 40-50 минут", "Discussion" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("1dc51594-8746-4bb9-ae4b-6f953a1e3411"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("4f8d5a07-45cd-4e3d-ab0b-b8c6b286dfb3"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("ce2bc301-8ff0-4d9f-ab40-8e1428b6df2b"));

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Statements");

            migrationBuilder.DropColumn(
                name: "SubmittedTime",
                table: "Statements");

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("8ba77d07-e26e-48a4-8a52-f344dcb1b5a1"), "Доклад, 35-45 минут", "Report" },
                    { new Guid("9adc585d-de90-4931-bb9e-5741d0c74746"), "Мастеркласс, 1-2 часа", "Masterclass" },
                    { new Guid("babd3aaa-6cab-46e3-a0d9-2a69d134da8c"), "Дискуссия / круглый стол, 40-50 минут", "Discussion" }
                });
        }
    }
}

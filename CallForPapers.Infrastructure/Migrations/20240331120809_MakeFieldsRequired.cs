using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CallForPapers.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeFieldsRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("70ec202b-68af-45ac-8c99-da403c8e1a4a"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("8b788ff7-5e1d-4fc0-855f-3567de2fe56c"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("c34ce821-2f94-43f1-ae4f-26daaa02313d"));

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("8e8186ef-2e65-45c9-8a6c-67bd6d4568c8"), "Доклад, 35-45 минут", "Report" },
                    { new Guid("d02ef514-0546-44b7-8627-81e1f809ecd5"), "Дискуссия / круглый стол, 40-50 минут", "Discussion" },
                    { new Guid("d6ba3e05-b767-4a49-a67e-b4e6f0633ded"), "Мастеркласс, 1-2 часа", "Masterclass" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("8e8186ef-2e65-45c9-8a6c-67bd6d4568c8"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("d02ef514-0546-44b7-8627-81e1f809ecd5"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("d6ba3e05-b767-4a49-a67e-b4e6f0633ded"));

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("70ec202b-68af-45ac-8c99-da403c8e1a4a"), "Доклад, 35-45 минут", "Report" },
                    { new Guid("8b788ff7-5e1d-4fc0-855f-3567de2fe56c"), "Дискуссия / круглый стол, 40-50 минут", "Discussion" },
                    { new Guid("c34ce821-2f94-43f1-ae4f-26daaa02313d"), "Мастеркласс, 1-2 часа", "Masterclass" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CallForPapers.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeOptionalSubmittedTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedTime",
                table: "Statements",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("397c652e-9f66-4c02-85ef-140a6fd7d6dd"), "Дискуссия / круглый стол, 40-50 минут", "Discussion" },
                    { new Guid("903dc6e2-4bef-41b8-9138-4003f923cbb2"), "Доклад, 35-45 минут", "Report" },
                    { new Guid("d0636f07-5e21-45ae-bdf8-eb5b9f37d031"), "Мастеркласс, 1-2 часа", "Masterclass" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("397c652e-9f66-4c02-85ef-140a6fd7d6dd"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("903dc6e2-4bef-41b8-9138-4003f923cbb2"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("d0636f07-5e21-45ae-bdf8-eb5b9f37d031"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedTime",
                table: "Statements",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

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
    }
}

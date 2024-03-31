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
            migrationBuilder.DropForeignKey(
                name: "FK_Statements_Activities_ActivityId",
                table: "Statements");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("8837a157-afbd-40c2-8be7-0b35ee7855a1"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("d91a80c5-e0cc-448c-a8cc-bc297291bbaa"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("f6858260-b1ff-4106-8ba0-daf8b80c3045"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivityId",
                table: "Statements",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1c8afd3d-4e74-48c9-b08e-d5d5ab34ef1d"), "Мастеркласс, 1-2 часа", "Masterclass" },
                    { new Guid("590b5753-1742-427b-8421-e3f73c33735e"), "Дискуссия / круглый стол, 40-50 минут", "Discussion" },
                    { new Guid("cbf54db1-ea5c-4c25-bc6c-24c87f93a832"), "Доклад, 35-45 минут", "Report" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Statements_Activities_ActivityId",
                table: "Statements",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statements_Activities_ActivityId",
                table: "Statements");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("1c8afd3d-4e74-48c9-b08e-d5d5ab34ef1d"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("590b5753-1742-427b-8421-e3f73c33735e"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("cbf54db1-ea5c-4c25-bc6c-24c87f93a832"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivityId",
                table: "Statements",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("8837a157-afbd-40c2-8be7-0b35ee7855a1"), "Доклад, 35-45 минут", "Report" },
                    { new Guid("d91a80c5-e0cc-448c-a8cc-bc297291bbaa"), "Мастеркласс, 1-2 часа", "Masterclass" },
                    { new Guid("f6858260-b1ff-4106-8ba0-daf8b80c3045"), "Дискуссия / круглый стол, 40-50 минут", "Discussion" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Statements_Activities_ActivityId",
                table: "Statements",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id");
        }
    }
}

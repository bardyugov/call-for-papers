using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CallForPapers.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Last : Migration
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
                keyValue: new Guid("220d3c44-4665-4643-801b-4d230d33145a"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("4bfa9f20-2dfb-46d0-8aee-1d802563400d"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("670ac606-82b7-4c24-b413-1883c570fc05"));

            migrationBuilder.AlterColumn<string>(
                name: "Outline",
                table: "Statements",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Statements",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Statements",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
                    { new Guid("118e8afa-e4ca-409a-994e-ca34eb916df1"), "Дискуссия / круглый стол, 40-50 минут", "Discussion" },
                    { new Guid("a1b0d873-952b-4d9d-8508-2b15e6a5f319"), "Мастеркласс, 1-2 часа", "Masterclass" },
                    { new Guid("e1eed7e4-8883-4854-8ca8-145a9f5a7c82"), "Доклад, 35-45 минут", "Report" }
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
                keyValue: new Guid("118e8afa-e4ca-409a-994e-ca34eb916df1"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("a1b0d873-952b-4d9d-8508-2b15e6a5f319"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("e1eed7e4-8883-4854-8ca8-145a9f5a7c82"));

            migrationBuilder.AlterColumn<string>(
                name: "Outline",
                table: "Statements",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Statements",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Statements",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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
                    { new Guid("220d3c44-4665-4643-801b-4d230d33145a"), "Дискуссия / круглый стол, 40-50 минут", "Discussion" },
                    { new Guid("4bfa9f20-2dfb-46d0-8aee-1d802563400d"), "Доклад, 35-45 минут", "Report" },
                    { new Guid("670ac606-82b7-4c24-b413-1883c570fc05"), "Мастеркласс, 1-2 часа", "Masterclass" }
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

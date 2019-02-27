using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UltraBugTracker.API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "AreaId", "AuthorId", "CloseDate", "CreateDate", "Description", "Status" },
                values: new object[] { 1, 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultra bug new", 1 });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "AreaId", "AuthorId", "CloseDate", "CreateDate", "Description", "Status" },
                values: new object[] { 2, 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultra bug in progress", 2 });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "AreaId", "AuthorId", "CloseDate", "CreateDate", "Description", "Status" },
                values: new object[] { 3, 0, 0, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultra bug closed", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

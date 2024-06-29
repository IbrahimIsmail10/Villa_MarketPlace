using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magic_Villa_VillaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddImageLocalPathToVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLocalPath",
                table: "villas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 99,
                column: "CreatedDate",
                value: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "CreatedDate",
                value: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 105,
                column: "CreatedDate",
                value: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLocalPath",
                table: "villas");

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 21, 20, 47, 30, 571, DateTimeKind.Local).AddTicks(606));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 21, 20, 47, 30, 571, DateTimeKind.Local).AddTicks(645));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 21, 20, 47, 30, 571, DateTimeKind.Local).AddTicks(647));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 21, 20, 47, 30, 571, DateTimeKind.Local).AddTicks(650));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 21, 20, 47, 30, 571, DateTimeKind.Local).AddTicks(652));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 99,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 21, 20, 47, 30, 571, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 21, 20, 47, 30, 571, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 105,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 21, 20, 47, 30, 571, DateTimeKind.Local).AddTicks(795));
        }
    }
}

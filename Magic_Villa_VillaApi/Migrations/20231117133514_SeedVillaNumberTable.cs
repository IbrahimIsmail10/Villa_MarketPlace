using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Magic_Villa_VillaApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaNumberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 35, 14, 178, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 35, 14, 178, DateTimeKind.Local).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 35, 14, 178, DateTimeKind.Local).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 35, 14, 178, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 35, 14, 178, DateTimeKind.Local).AddTicks(2492));

            migrationBuilder.InsertData(
                table: "villasNo",
                columns: new[] { "VillaNo", "CreatedDate", "SpecialDetails", "UpdatedDate" },
                values: new object[,]
                {
                    { 99, new DateTime(2023, 11, 17, 15, 35, 14, 178, DateTimeKind.Local).AddTicks(2857), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, new DateTime(2023, 11, 17, 15, 35, 14, 178, DateTimeKind.Local).AddTicks(2848), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 105, new DateTime(2023, 11, 17, 15, 35, 14, 178, DateTimeKind.Local).AddTicks(2862), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 105);

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 4, 10, 41, 532, DateTimeKind.Local).AddTicks(8029));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 4, 10, 41, 532, DateTimeKind.Local).AddTicks(8095));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 4, 10, 41, 532, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 4, 10, 41, 532, DateTimeKind.Local).AddTicks(8105));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 4, 10, 41, 532, DateTimeKind.Local).AddTicks(8110));
        }
    }
}

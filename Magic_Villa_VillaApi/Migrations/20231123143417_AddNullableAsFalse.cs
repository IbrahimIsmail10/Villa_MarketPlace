using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magic_Villa_VillaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddNullableAsFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "villasNo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Amenity",
                table: "villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 23, 16, 34, 17, 335, DateTimeKind.Local).AddTicks(9643));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 23, 16, 34, 17, 335, DateTimeKind.Local).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 23, 16, 34, 17, 335, DateTimeKind.Local).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 23, 16, 34, 17, 335, DateTimeKind.Local).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 23, 16, 34, 17, 335, DateTimeKind.Local).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 99,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 23, 16, 34, 17, 335, DateTimeKind.Local).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 23, 16, 34, 17, 335, DateTimeKind.Local).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 105,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 23, 16, 34, 17, 335, DateTimeKind.Local).AddTicks(9971));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "villasNo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Amenity",
                table: "villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 50, 57, 247, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 50, 57, 247, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 50, 57, 247, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 50, 57, 247, DateTimeKind.Local).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 50, 57, 247, DateTimeKind.Local).AddTicks(1105));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 99,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 50, 57, 247, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 50, 57, 247, DateTimeKind.Local).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 105,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 50, 57, 247, DateTimeKind.Local).AddTicks(1296));
        }
    }
}

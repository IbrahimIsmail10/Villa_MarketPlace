using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magic_Villa_VillaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToVillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaID",
                table: "villasNo",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "CreatedDate", "VillaID" },
                values: new object[] { new DateTime(2023, 11, 17, 15, 50, 57, 247, DateTimeKind.Local).AddTicks(1293), 0 });

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 101,
                columns: new[] { "CreatedDate", "VillaID" },
                values: new object[] { new DateTime(2023, 11, 17, 15, 50, 57, 247, DateTimeKind.Local).AddTicks(1288), 0 });

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 105,
                columns: new[] { "CreatedDate", "VillaID" },
                values: new object[] { new DateTime(2023, 11, 17, 15, 50, 57, 247, DateTimeKind.Local).AddTicks(1296), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_villasNo_VillaID",
                table: "villasNo",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_villasNo_villas_VillaID",
                table: "villasNo",
                column: "VillaID",
                principalTable: "villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villasNo_villas_VillaID",
                table: "villasNo");

            migrationBuilder.DropIndex(
                name: "IX_villasNo_VillaID",
                table: "villasNo");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "villasNo");

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

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 99,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 35, 14, 178, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 35, 14, 178, DateTimeKind.Local).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 105,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 15, 35, 14, 178, DateTimeKind.Local).AddTicks(2862));
        }
    }
}

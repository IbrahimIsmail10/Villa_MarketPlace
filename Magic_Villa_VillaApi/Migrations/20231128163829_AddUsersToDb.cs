using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magic_Villa_VillaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 28, 18, 38, 29, 298, DateTimeKind.Local).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 28, 18, 38, 29, 298, DateTimeKind.Local).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 28, 18, 38, 29, 298, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 28, 18, 38, 29, 298, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 28, 18, 38, 29, 298, DateTimeKind.Local).AddTicks(9958));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 99,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 28, 18, 38, 29, 299, DateTimeKind.Local).AddTicks(185));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 28, 18, 38, 29, 299, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.UpdateData(
                table: "villasNo",
                keyColumn: "VillaNo",
                keyValue: 105,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 28, 18, 38, 29, 299, DateTimeKind.Local).AddTicks(189));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

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
    }
}

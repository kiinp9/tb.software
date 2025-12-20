using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace traobang.be.infrastructure.data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTblDssv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdSinhVienNhanBang",
                schema: "tb",
                table: "Slide",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySinh",
                schema: "tb",
                table: "DanhSachSinhVienNhanBang",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayQuyetDinh",
                schema: "tb",
                table: "DanhSachSinhVienNhanBang",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdSinhVienNhanBang",
                schema: "tb",
                table: "Slide",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySinh",
                schema: "tb",
                table: "DanhSachSinhVienNhanBang",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayQuyetDinh",
                schema: "tb",
                table: "DanhSachSinhVienNhanBang",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}

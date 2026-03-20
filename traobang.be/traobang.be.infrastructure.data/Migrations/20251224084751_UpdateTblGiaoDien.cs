using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace traobang.be.infrastructure.data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTblGiaoDien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                schema: "tb",
                table: "GiaoDien",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Css",
                schema: "tb",
                table: "GiaoDien",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Html",
                schema: "tb",
                table: "GiaoDien",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Js",
                schema: "tb",
                table: "GiaoDien",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Css",
                schema: "tb",
                table: "GiaoDien");

            migrationBuilder.DropColumn(
                name: "Html",
                schema: "tb",
                table: "GiaoDien");

            migrationBuilder.DropColumn(
                name: "Js",
                schema: "tb",
                table: "GiaoDien");

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                schema: "tb",
                table: "GiaoDien",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}

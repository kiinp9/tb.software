using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace traobang.be.infrastructure.data.Migrations
{
    /// <inheritdoc />
    public partial class updatetbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Plan",
                schema: "tb",
                table: "GiaoDien",
                newName: "IX_GiaoDien");

            migrationBuilder.AlterColumn<int>(
                name: "IdGiaoDien",
                schema: "tb",
                table: "Plan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_GiaoDien",
                schema: "tb",
                table: "GiaoDien",
                newName: "IX_Plan");

            migrationBuilder.AlterColumn<int>(
                name: "IdGiaoDien",
                schema: "tb",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}

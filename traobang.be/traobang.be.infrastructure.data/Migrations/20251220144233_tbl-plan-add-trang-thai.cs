using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace traobang.be.infrastructure.data.Migrations
{
    /// <inheritdoc />
    public partial class tblplanaddtrangthai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                schema: "tb",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThai",
                schema: "tb",
                table: "Plan");
        }
    }
}

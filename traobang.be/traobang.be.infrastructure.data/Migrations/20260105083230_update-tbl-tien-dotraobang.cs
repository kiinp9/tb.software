using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace traobang.be.infrastructure.data.Migrations
{
    /// <inheritdoc />
    public partial class updatetbltiendotraobang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPlan",
                schema: "tb",
                table: "TienDoTraoBang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSlide",
                schema: "tb",
                table: "TienDoTraoBang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoaiSlide",
                schema: "tb",
                table: "TienDoTraoBang",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPlan",
                schema: "tb",
                table: "TienDoTraoBang");

            migrationBuilder.DropColumn(
                name: "IdSlide",
                schema: "tb",
                table: "TienDoTraoBang");

            migrationBuilder.DropColumn(
                name: "LoaiSlide",
                schema: "tb",
                table: "TienDoTraoBang");
        }
    }
}

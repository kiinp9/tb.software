using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace traobang.be.infrastructure.data.Migrations
{
    /// <inheritdoc />
    public partial class AddGiaoDienMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdGiaoDien",
                schema: "tb",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GiaoDien",
                schema: "tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGiaoDien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoDien", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plan_IdGiaoDien",
                schema: "tb",
                table: "Plan",
                column: "IdGiaoDien");

            migrationBuilder.CreateIndex(
                name: "IX_Plan",
                schema: "tb",
                table: "GiaoDien",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_GiaoDien_IdGiaoDien",
                schema: "tb",
                table: "Plan",
                column: "IdGiaoDien",
                principalSchema: "tb",
                principalTable: "GiaoDien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_GiaoDien_IdGiaoDien",
                schema: "tb",
                table: "Plan");

            migrationBuilder.DropTable(
                name: "GiaoDien",
                schema: "tb");

            migrationBuilder.DropIndex(
                name: "IX_Plan_IdGiaoDien",
                schema: "tb",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "IdGiaoDien",
                schema: "tb",
                table: "Plan");
        }
    }
}

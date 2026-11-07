using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLearning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAssetsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "CopyBooks");

            migrationBuilder.AddColumn<Guid>(
                name: "CoverId",
                table: "CopyBooks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    MimeType = table.Column<string>(type: "TEXT", nullable: false),
                    SizeInBytes = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CopyBooks_CoverId",
                table: "CopyBooks",
                column: "CoverId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Name",
                table: "Assets",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_CopyBooks_Assets_CoverId",
                table: "CopyBooks",
                column: "CoverId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CopyBooks_Assets_CoverId",
                table: "CopyBooks");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_CopyBooks_CoverId",
                table: "CopyBooks");

            migrationBuilder.DropColumn(
                name: "CoverId",
                table: "CopyBooks");

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "CopyBooks",
                type: "TEXT",
                nullable: true);
        }
    }
}

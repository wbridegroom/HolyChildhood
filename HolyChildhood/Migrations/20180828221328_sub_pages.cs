using Microsoft.EntityFrameworkCore.Migrations;

namespace HolyChildhood.Migrations
{
    public partial class sub_pages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Pages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ParentId",
                table: "Pages",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Pages_ParentId",
                table: "Pages",
                column: "ParentId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Pages_ParentId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_ParentId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Pages");
        }
    }
}

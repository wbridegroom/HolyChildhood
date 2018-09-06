using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HolyChildhood.Migrations
{
    public partial class settings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    CanDelete = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.UniqueConstraint("AlternateKey_Key", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CanDelete", "Key", "Value" },
                values: new object[,]
                {
                    { 1, false, "Title", "Holy Childhood of Jesus" },
                    { 2, false, "Phone", "" },
                    { 3, false, "Email", "" },
                    { 4, false, "Address", "" },
                    { 5, false, "City", "" },
                    { 6, false, "State", "" },
                    { 7, false, "Zipcode", "" },
                    { 8, false, "Mission_Statement", "" },
                    { 9, false, "Quote", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}

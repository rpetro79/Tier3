using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3.Migrations
{
    public partial class Technologies_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Applications",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryList",
                columns: table => new
                {
                    Category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryList", x => x.Category);
                });

            migrationBuilder.CreateTable(
                name: "TechnologyList",
                columns: table => new
                {
                    Technology = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologyList", x => x.Technology);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryList");

            migrationBuilder.DropTable(
                name: "TechnologyList");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "Approved",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

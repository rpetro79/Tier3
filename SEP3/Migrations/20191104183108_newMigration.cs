using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "technologiessss",
                newName: "technologies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "technologies",
                newName: "technologiessss");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3.Migrations
{
    public partial class DbProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "CustomerUsername",
                table: "Projects",
                newName: "customerUsername");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "customerUsername",
                table: "Projects",
                newName: "CustomerUsername");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

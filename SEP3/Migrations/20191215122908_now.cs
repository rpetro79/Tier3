using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3.Migrations
{
    public partial class now : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProposalId",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "Applications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "ProposalId",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

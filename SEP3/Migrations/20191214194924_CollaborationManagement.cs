using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3.Migrations
{
    public partial class CollaborationManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contactInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collaborations",
                table: "Collaborations");

            migrationBuilder.DropColumn(
                name: "CollaborationId",
                table: "Collaborations");

            migrationBuilder.DropColumn(
                name: "ProposalId",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "Collaborations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "Applications",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collaborations",
                table: "Collaborations",
                column: "ProjectId");

            migrationBuilder.CreateTable(
                name: "CollaborationManagement",
                columns: table => new
                {
                    ProjectId = table.Column<string>(nullable: false),
                    Closed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborationManagement", x => x.ProjectId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaborationManagement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collaborations",
                table: "Collaborations");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Collaborations");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "CollaborationId",
                table: "Collaborations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProposalId",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collaborations",
                table: "Collaborations",
                column: "CollaborationId");

            
        }
    }
}

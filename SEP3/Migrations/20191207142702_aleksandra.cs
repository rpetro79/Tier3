using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3.Migrations
{
    public partial class aleksandra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collaborations",
                columns: table => new
                {
                    CollaborationId = table.Column<string>(nullable: false),
                    CollaborationName = table.Column<string>(nullable: true),
                    ITProviderName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborations", x => x.CollaborationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collaborations");
        }
    }
}
